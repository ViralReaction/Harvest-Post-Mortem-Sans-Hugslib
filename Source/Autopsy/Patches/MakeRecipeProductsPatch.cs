using System.Collections.Generic;
using System.Linq;
using Autopsy.Util;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Autopsy
{
    [HarmonyPatch(typeof(GenRecipe), nameof(GenRecipe.MakeRecipeProducts))]
    [HarmonyPatch(MethodType.Normal)]
    public static class MakeRecipeProductsPatch
    {
        [HarmonyPostfix]
        public static void Postfix(ref IEnumerable<Thing> __result, RecipeDef recipeDef, Pawn worker,
            List<Thing> ingredients)
        {
            if (Constants.HumanRecipeDefs.Contains(recipeDef))
            {
                RecipeInfo recipeSettings = null;
                float skillChance = worker.GetStatValue(StatDefOf.MedicalSurgerySuccessChance);
                if (recipeDef.Equals(AutopsyRecipeDefs.AutopsyBasic))
                {
                    recipeSettings = new RecipeInfo(
                        ModSettings_PostMortem.BasicAutopsyOrganMaxChance,
                        ModSettings_PostMortem.BasicAutopsyCorpseAge * 2500,
                        ModSettings_PostMortem.BasicAutopsyBionicMaxChance,
                        ModSettings_PostMortem.BasicAutopsyMaxNumberOfOrgans,
                        ModSettings_PostMortem.BasicAutopsyFrozenDecay);
                    skillChance *= ModSettings_PostMortem.BasicAutopsyMedicalSkillScaling;
                }
                else if (recipeDef.Equals(AutopsyRecipeDefs.AutopsyAdvanced))
                {
                    recipeSettings = new RecipeInfo(
                        ModSettings_PostMortem.AdvancedAutopsyOrganMaxChance,
                        ModSettings_PostMortem.AdvancedAutopsyCorpseAge * 2500,
                        ModSettings_PostMortem.AdvancedAutopsyBionicMaxChance,
                        ModSettings_PostMortem.AdvancedAutopsyMaxNumberOfOrgans,
                            ModSettings_PostMortem.AdvancedAutopsyFrozenDecay);
                    skillChance *= ModSettings_PostMortem.AdvancedAutopsyMedicalSkillScaling;
                }
                else if (recipeDef.Equals(AutopsyRecipeDefs.AutopsyGlitterworld))
                {
                    recipeSettings = new RecipeInfo(
                        ModSettings_PostMortem.GlitterAutopsyOrganMaxChance,
                        ModSettings_PostMortem.GlitterAutopsyCorpseAge * 2500,
                        ModSettings_PostMortem.GlitterAutopsyBionicMaxChance,
                        ModSettings_PostMortem.GlitterAutopsyMaxNumberOfOrgans,
                        ModSettings_PostMortem.GlitterAutopsyFrozenDecay);
                    skillChance *= ModSettings_PostMortem.GlitterAutopsyMedicalSkillScaling;
                }
                else if (recipeDef.Equals(AutopsyRecipeDefs.AutopsyAnimal))
                {
                    recipeSettings = new RecipeInfo(
                        0f,
                        0,
                        ModSettings_PostMortem.AnimalAutopsyBionicMaxChance,
                        ModSettings_PostMortem.AnimalAutopsyMaxNumberOfOrgans,
                        0);
                    skillChance *= ModSettings_PostMortem.AnimalAutopsyMedicalSkillScaling;
                }

                if (recipeSettings == null) return;
                List<Thing> result = __result as List<Thing> ?? __result.ToList();
                foreach (Corpse corpse in ingredients.OfType<Corpse>())
                    result.AddRange(
                        NewMedicalRecipesUtility.TraverseBody(recipeSettings, corpse, skillChance));

                if (recipeDef.Equals(AutopsyRecipeDefs.AutopsyBasic))
                {
                    worker.needs?.mood?.thoughts?.memories?.TryGainMemory(AutopsyRecipeDefs.HarvestedHumanlikeCorpse, null);
                    foreach (Pawn pawn in worker.Map.mapPawns.SpawnedPawnsInFaction(worker.Faction))
                        if (pawn != worker)
                            pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(
                                AutopsyRecipeDefs.KnowHarvestedHumanlikeCorpse, null);
                }

                __result = result;
            }
        }
    }
}