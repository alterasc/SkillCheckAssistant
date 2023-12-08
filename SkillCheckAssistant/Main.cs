using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace SkillCheckAssistant
{
#if DEBUG
    [EnableReloading]
#endif
    static class Main
    {
        public static bool Enabled;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static UnityModManager.ModEntry ModEntry;
        public static CheckAssistantSettings Settings;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = new Harmony(modEntry.Info.Id);
            Settings = UnityModManager.ModSettings.Load<CheckAssistantSettings>(modEntry);
            ModEntry = modEntry;
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
#if DEBUG
            modEntry.OnUnload = OnUnload;
#endif
            harmony.PatchAll();
            return true;
        }

#if DEBUG
        static bool OnUnload(UnityModManager.ModEntry modEntry)
        {
            return true;
        }
#endif
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Enabled = value;
            return true;
        }

        static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            GUILayout.BeginHorizontal();
            Settings.OnlyOutOfCombat = GUILayout.Toggle(Settings.OnlyOutOfCombat, "Only out of combat rolls");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            Settings.RollIfTakeIsNotEnough = GUILayout.Toggle(Settings.RollIfTakeIsNotEnough, "If chosen \"Take X\" value is not low enough to succeed, try rolling check normally.");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(40);
            GUILayout.EndHorizontal();

            string[] toolbarStrings = { "Roll normally", "Take 50", "Take 33", "Take 25", "Take 10", "Take 1" };
            var labelWidth = GUILayout.Width(GUI.skin.label.CalcSize(new GUIContent("Lore (Imperium)   ")).x);

            var toolbarButtonStyle = new GUIStyle(GUI.skin.button)
            {
                fixedWidth = GUI.skin.button.CalcSize(new GUIContent("Roll normally  ")).x
            };

            GUILayout.BeginHorizontal();
            GUILayout.Label("Weapon Skill", labelWidth);
            Settings.WarhammerWeaponSkill = GUILayout.Toolbar(Settings.WarhammerWeaponSkill, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Ballistic Skill", labelWidth);
            Settings.WarhammerBallisticSkill = GUILayout.Toolbar(Settings.WarhammerBallisticSkill, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Strength", labelWidth);
            Settings.WarhammerStrength = GUILayout.Toolbar(Settings.WarhammerStrength, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Toughness", labelWidth);
            Settings.WarhammerToughness = GUILayout.Toolbar(Settings.WarhammerToughness, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Agility", labelWidth);
            Settings.WarhammerAgility = GUILayout.Toolbar(Settings.WarhammerAgility, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Intelligence", labelWidth);
            Settings.WarhammerIntelligence = GUILayout.Toolbar(Settings.WarhammerIntelligence, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Perception", labelWidth);
            Settings.WarhammerPerception = GUILayout.Toolbar(Settings.WarhammerPerception, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Willpower", labelWidth);
            Settings.WarhammerWillpower = GUILayout.Toolbar(Settings.WarhammerWillpower, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Fellowship", labelWidth);
            Settings.WarhammerFellowship = GUILayout.Toolbar(Settings.WarhammerFellowship, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(40);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Athletics", labelWidth);
            Settings.SkillAthletics = GUILayout.Toolbar(Settings.SkillAthletics, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Carouse", labelWidth);
            Settings.SkillCarouse = GUILayout.Toolbar(Settings.SkillCarouse, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Demolition", labelWidth);
            Settings.SkillDemolition = GUILayout.Toolbar(Settings.SkillDemolition, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Logic", labelWidth);
            Settings.SkillLogic = GUILayout.Toolbar(Settings.SkillLogic, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Lore (Imperium)", labelWidth);
            Settings.SkillLoreImperium = GUILayout.Toolbar(Settings.SkillLoreImperium, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Lore (Warp)", labelWidth);
            Settings.SkillLoreWarp = GUILayout.Toolbar(Settings.SkillLoreWarp, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Lore (Xenos)", labelWidth);
            Settings.SkillLoreXenos = GUILayout.Toolbar(Settings.SkillLoreXenos, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Medicae", labelWidth);
            Settings.SkillMedicae = GUILayout.Toolbar(Settings.SkillMedicae, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Tech Use", labelWidth);
            Settings.SkillTechUse = GUILayout.Toolbar(Settings.SkillTechUse, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Awareness", labelWidth);
            Settings.SkillAwareness = GUILayout.Toolbar(Settings.SkillAwareness, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Coercion", labelWidth);
            Settings.SkillCoercion = GUILayout.Toolbar(Settings.SkillCoercion, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Commerce", labelWidth);
            Settings.SkillCommerce = GUILayout.Toolbar(Settings.SkillCommerce, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Persuasion", labelWidth);
            Settings.SkillPersuasion = GUILayout.Toolbar(Settings.SkillPersuasion, toolbarStrings, toolbarButtonStyle);
            GUILayout.EndHorizontal();

            if (GUI.changed)
            {
                Settings.Save(modEntry);
            }
        }
        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Settings.Save(modEntry);
        }
    }
}