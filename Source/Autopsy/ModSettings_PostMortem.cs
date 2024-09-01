using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.Noise;

namespace Autopsy
{
    public class ModSettings_PostMortem : ModSettings
    {
        public override void ExposeData()
        {
            Scribe_Values.Look<float>(ref BasicAutopsyOrganMaxChance, "BasicAutopsyOrganMaxChance", 0.4f);
            Scribe_Values.Look<int>(ref BasicAutopsyMaxNumberOfOrgans, "BasicAutopsyMaxNumberOfOrgans", 99);
            Scribe_Values.Look<int>(ref BasicAutopsyCorpseAge, "BasicAutopsyCorpseAge", 3);
            Scribe_Values.Look<float>(ref BasicAutopsyBionicMaxChance, "BasicAutopsyBionicMaxChance", 0f);
            Scribe_Values.Look<float>(ref BasicAutopsyMedicalSkillScaling, "BasicAutopsyMedicalSkillScaling", 1f);
            Scribe_Values.Look<float>(ref BasicAutopsyFrozenDecay, "BasicAutopsyFrozenDecay", 0f);
            Scribe_Values.Look<int>(ref AdvancedAutopsyMaxNumberOfOrgans, "AdvancedAutopsyMaxNumberOfOrgans", 99);
            Scribe_Values.Look<float>(ref AdvancedAutopsyOrganMaxChance, "AdvancedAutopsyOrganMaxChance", 0.8f);
            Scribe_Values.Look<int>(ref AdvancedAutopsyCorpseAge, "AdvancedAutopsyCorpseAge", 6);
            Scribe_Values.Look<float>(ref AdvancedAutopsyBionicMaxChance, "AdvancedAutopsyBionicMaxChance", 0.4f);
            Scribe_Values.Look<float>(ref AdvancedAutopsyMedicalSkillScaling, "AdvancedAutopsyMedicalSkillScaling", 1f);
            Scribe_Values.Look<float>(ref AdvancedAutopsyFrozenDecay, "AdvancedAutopsyFrozenDecay", 0f);
            Scribe_Values.Look<int>(ref GlitterAutopsyMaxNumberOfOrgans, "GlitterAutopsyMaxNumberOfOrgans", 99);
            Scribe_Values.Look<float>(ref GlitterAutopsyOrganMaxChance, "GlitterAutopsyOrganMaxChance", 0.95f);
            Scribe_Values.Look<int>(ref GlitterAutopsyCorpseAge, "GlitterAutopsyCorpseAge", 12);
            Scribe_Values.Look<float>(ref GlitterAutopsyBionicMaxChance, "GlitterAutopsyBionicMaxChance", 0.8f);
            Scribe_Values.Look<float>(ref GlitterAutopsyMedicalSkillScaling, "GlitterAutopsyMedicalSkillScaling", 1f);
            Scribe_Values.Look<float>(ref GlitterAutopsyFrozenDecay, "GlitterAutopsyFrozenDecay", 0);
            Scribe_Values.Look<int>(ref AnimalAutopsyMaxNumberOfOrgans, "AnimalAutopsyMaxNumberOfOrgans", 99);
            Scribe_Values.Look<float>(ref AnimalAutopsyBionicMaxChance, "AnimalAutopsyBionicMaxChance", 0.6f);
            Scribe_Values.Look<float>(ref AnimalAutopsyMedicalSkillScaling, "AnimalAutopsyMedicalSkillScaling", 0.8f);

            base.ExposeData();
        }
        private Vector2 scrollPosition;
        public void DoSettingsWindowContents(Rect inRect)
        {
            //Rect inner = inRect.ContractedBy(20f);
            Rect rect = new Rect(inRect.x, inRect.y, inRect.width - 20f, inRect.height);
            rect.height = 1000f;
            Widgets.BeginScrollView(inRect, ref this.scrollPosition, rect, true);
            Listing_PostMortem options = new Listing_PostMortem();
            options.Begin(rect);
            options.GapLine();
            // Basic Autopsy
            Text.Font = GameFont.Medium;
            options.Label("autopsyBasicTab".Translate());
            Text.Font = GameFont.Small;
            BasicAutopsyOrganMaxChance = options.CustomSliderLabel("organChanceTitle".Translate() + ":", BasicAutopsyOrganMaxChance, 0f, 1f, 0.5f, "organChanceDescription".Translate(), (BasicAutopsyOrganMaxChance * 100).ToString("F2") + "%", 1f.ToString(), 0f.ToString(), 0.01f);
            BasicAutopsyBionicMaxChance = options.CustomSliderLabel("bionicChanceTitle".Translate() + ":", BasicAutopsyBionicMaxChance, 0f, 1f, 0.5f, "bionicChanceDescription".Translate(),(BasicAutopsyBionicMaxChance * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.01f);
            BasicAutopsyCorpseAge = options.CustomSliderLabelInt("corpseAgeTitle".Translate() + ":", BasicAutopsyCorpseAge, 0, 100, 0.5f, "corpseAgeDescription".Translate(), BasicAutopsyCorpseAge.ToString(), 100.ToString(), 0.ToString(), 1);
            BasicAutopsyMaxNumberOfOrgans = options.CustomSliderLabelInt("numberPartsTitle".Translate() + ":", BasicAutopsyMaxNumberOfOrgans, 0, 99, 0.5f, "numberPartsDescription".Translate(), BasicAutopsyMaxNumberOfOrgans.ToString(), 99.ToString(), 0.ToString(), 1);
            BasicAutopsyMedicalSkillScaling = options.CustomSliderLabel("skillScalingTitle".Translate() + ":", BasicAutopsyMedicalSkillScaling, 0f, 10f, 0.5f, "skillScalingDescription".Translate(), (BasicAutopsyMedicalSkillScaling * 100).ToString("F2") + " % ", 10f.ToString(), 0f.ToString(), 0.01f);
            BasicAutopsyFrozenDecay = options.CustomSliderLabel("frozenDecayTitle".Translate() + ":", BasicAutopsyFrozenDecay, 0f, 1f, 0.5f, "frozenDecayDescription".Translate(), (BasicAutopsyFrozenDecay * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.01f);
            options.GapLine();

            // Advanced Autopsy
            Text.Font = GameFont.Medium;
            options.Label("autopsyAdvancedTab".Translate());
            Text.Font = GameFont.Small;
            AdvancedAutopsyOrganMaxChance = options.CustomSliderLabel("organChanceTitle".Translate() + ":", AdvancedAutopsyOrganMaxChance, 0f, 1f, 0.5f, "organChanceDescription".Translate(), (AdvancedAutopsyOrganMaxChance * 100).ToString("F2") + "%", 1f.ToString(), 0f.ToString(), 0.01f);
            AdvancedAutopsyBionicMaxChance = options.CustomSliderLabel("bionicChanceTitle".Translate() + ":", AdvancedAutopsyBionicMaxChance, 0f, 1f, 0.5f, "bionicChanceDescription".Translate(), (AdvancedAutopsyBionicMaxChance * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.01f);
            AdvancedAutopsyCorpseAge = options.CustomSliderLabelInt("corpseAgeTitle".Translate() + ":", AdvancedAutopsyCorpseAge, 0, 100, 0.5f, "corpseAgeDescription".Translate(), AdvancedAutopsyCorpseAge.ToString(), 100.ToString(), 0.ToString(), 1);
            AdvancedAutopsyMaxNumberOfOrgans = options.CustomSliderLabelInt("numberPartsTitle".Translate() + ":", AdvancedAutopsyMaxNumberOfOrgans, 0, 99, 0.5f, "numberPartsDescription".Translate(), AdvancedAutopsyMaxNumberOfOrgans.ToString(), 99.ToString(), 0.ToString(), 1);
            AdvancedAutopsyMedicalSkillScaling = options.CustomSliderLabel("skillScalingTitle".Translate() + ":", AdvancedAutopsyMedicalSkillScaling, 0f, 10f, 0.5f, "skillScalingDescription".Translate(),(AdvancedAutopsyMedicalSkillScaling * 100).ToString("F2") + "%", 10f.ToString(), 0f.ToString(), 0.01f);
            AdvancedAutopsyFrozenDecay = options.CustomSliderLabel("frozenDecayTitle".Translate() + ":", AdvancedAutopsyFrozenDecay, 0f, 1f, 0.5f, "frozenDecayDescription".Translate(), (AdvancedAutopsyFrozenDecay * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.05f);
            options.GapLine();
            // Glitter Autopsy
            Text.Font = GameFont.Medium;
            options.Label("autopsyGlitterTab".Translate());
            Text.Font = GameFont.Small;
            GlitterAutopsyOrganMaxChance = options.CustomSliderLabel("organChanceTitle".Translate() + ":", GlitterAutopsyOrganMaxChance, 0f, 1f, 0.5f, "organChanceDescription".Translate(), (GlitterAutopsyOrganMaxChance * 100).ToString("F2") + "%", 1f.ToString(), 0f.ToString(), 0.01f);
            GlitterAutopsyBionicMaxChance = options.CustomSliderLabel("bionicChanceTitle".Translate() + ":", GlitterAutopsyBionicMaxChance, 0f, 1f, 0.5f, "bionicChanceDescription".Translate(), (GlitterAutopsyBionicMaxChance * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.01f);
            GlitterAutopsyCorpseAge = options.CustomSliderLabelInt("corpseAgeTitle".Translate() + ":", GlitterAutopsyCorpseAge, 0, 100, 0.5f, "corpseAgeDescription".Translate(), GlitterAutopsyCorpseAge.ToString(), 100.ToString(), 0.ToString(), 1);
            GlitterAutopsyMaxNumberOfOrgans = options.CustomSliderLabelInt("numberPartsTitle".Translate() + ":", GlitterAutopsyMaxNumberOfOrgans, 0, 99, 0.5f, "numberPartsDescription".Translate(), GlitterAutopsyMaxNumberOfOrgans.ToString(), 99.ToString(), 0.ToString(), 1);
            GlitterAutopsyMedicalSkillScaling = options.CustomSliderLabel("skillScalingTitle".Translate() + ":", GlitterAutopsyMedicalSkillScaling, 0f, 10f, 0.5f, "skillScalingDescription".Translate(), (GlitterAutopsyMedicalSkillScaling * 100).ToString("F2") + "%", 10f.ToString(), 0f.ToString(), 0.01f);
            GlitterAutopsyFrozenDecay = options.CustomSliderLabel("frozenDecayTitle".Translate() + ":", GlitterAutopsyFrozenDecay, 0f, 1f, 0.5f, "frozenDecayDescription".Translate(), (GlitterAutopsyFrozenDecay * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.01f);
            options.GapLine();
            // Animal Autopsy
            Text.Font = GameFont.Medium;
            options.Label("Animal Autopsy");
            Text.Font = GameFont.Small;
            AnimalAutopsyBionicMaxChance = options.CustomSliderLabel("bionicChanceTitle".Translate() + ":", AnimalAutopsyBionicMaxChance, 0f, 1f, 0.5f, "bionicChanceDescription".Translate(), (AnimalAutopsyBionicMaxChance * 100).ToString("F2") + " % ", 1f.ToString(), 0f.ToString(), 0.01f);
            AnimalAutopsyMaxNumberOfOrgans = options.CustomSliderLabelInt("numberPartsTitle".Translate() + ":", AnimalAutopsyMaxNumberOfOrgans, 0, 99, 0.5f, "numberPartsDescription".Translate(), AnimalAutopsyMaxNumberOfOrgans.ToString(), 99.ToString(), 0.ToString(), 1);
            AnimalAutopsyMedicalSkillScaling = options.CustomSliderLabel("skillScalingTitle".Translate() + ":", AnimalAutopsyMedicalSkillScaling, 0f, 10f, 0.5f, "skillScalingDescription".Translate(), (AnimalAutopsyMedicalSkillScaling * 100).ToString("F2") + "%", 10f.ToString(), 0f.ToString(), 0.01f);
            options.GapLine();
            options.Gap();
            if (options.ButtonText("Reset to Defaults"))
            {
                ResetSettingsToDefault();
            }

            options.End();
            Widgets.EndScrollView();
        }
        private void ResetSettingsToDefault()
        {
            BasicAutopsyOrganMaxChance = 0.4f;
            BasicAutopsyBionicMaxChance = 0f;
            BasicAutopsyMedicalSkillScaling = 1f;
            BasicAutopsyFrozenDecay = 0f;
            AdvancedAutopsyOrganMaxChance = 0.8f;
            AdvancedAutopsyBionicMaxChance = 0.4f;
            AdvancedAutopsyMedicalSkillScaling = 1f;
            AdvancedAutopsyFrozenDecay = 0f;
            GlitterAutopsyOrganMaxChance = 0.95f;
            GlitterAutopsyBionicMaxChance = 0.8f;
            GlitterAutopsyMedicalSkillScaling = 1f;
            GlitterAutopsyFrozenDecay = 0f;
            AnimalAutopsyBionicMaxChance = 0.6f;
            AnimalAutopsyMedicalSkillScaling = 0.8f;

            BasicAutopsyMaxNumberOfOrgans = 99;
            BasicAutopsyCorpseAge = 3;
            AdvancedAutopsyMaxNumberOfOrgans = 99;
            AdvancedAutopsyCorpseAge = 6;
            GlitterAutopsyMaxNumberOfOrgans = 99;
            GlitterAutopsyCorpseAge = 12;
            AnimalAutopsyMaxNumberOfOrgans = 99;
        }

        public static float
            BasicAutopsyOrganMaxChance = 0.4f,
            BasicAutopsyBionicMaxChance = 0f,
            BasicAutopsyMedicalSkillScaling = 1f,
            BasicAutopsyFrozenDecay = 0f,
            AdvancedAutopsyOrganMaxChance = 0.8f,
            AdvancedAutopsyBionicMaxChance = 0.4f,
            AdvancedAutopsyMedicalSkillScaling = 1f,
            AdvancedAutopsyFrozenDecay = 0f,
            GlitterAutopsyOrganMaxChance = 0.95f,
            GlitterAutopsyBionicMaxChance = 0.8f,
            GlitterAutopsyMedicalSkillScaling = 1f,
            GlitterAutopsyFrozenDecay = 0f,
            AnimalAutopsyBionicMaxChance = 0.6f,
            AnimalAutopsyMedicalSkillScaling = 0.8f;

        public static int
           BasicAutopsyMaxNumberOfOrgans = 99,
            BasicAutopsyCorpseAge = 3,
            AdvancedAutopsyMaxNumberOfOrgans = 99,
            AdvancedAutopsyCorpseAge = 6,
            GlitterAutopsyMaxNumberOfOrgans = 99,
            GlitterAutopsyCorpseAge = 12,
            AnimalAutopsyMaxNumberOfOrgans = 99;
    }
}