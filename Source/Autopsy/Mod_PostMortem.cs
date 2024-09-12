using System.Collections.Generic;
using Autopsy.Util;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace Autopsy
{
    public class Mod_PostMortem : Mod
    {

        public static ModSettings_PostMortem settings;
        public Mod_PostMortem(ModContentPack content) : base(content)
		{
            settings = GetSettings<ModSettings_PostMortem>();
            Harmony harmony = new Harmony(this.Content.PackageIdPlayerFacing);
            harmony.PatchAll();
         
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory()
        {
            return "Harvest Post Mortem";
        }
        public override void WriteSettings()
        {
            base.WriteSettings();
        }

    }
}