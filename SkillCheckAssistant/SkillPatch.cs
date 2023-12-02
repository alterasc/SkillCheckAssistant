using HarmonyLib;
using Kingmaker;
using Kingmaker.EntitySystem.Stats.Base;
using Kingmaker.RuleSystem.Rules;

namespace SkillCheckAssistant
{
    [HarmonyPatch(typeof(RulePerformSkillCheck))]
    public class SkillPatch
    {
        [HarmonyPatch(nameof(RulePerformSkillCheck.RollChanceRule))]
        [HarmonyPrefix]
        public static bool RulePerformSkillCheck_RollChanceRule(RulePerformSkillCheck __instance, ref RuleRollChance __result)
        {
            if (!__instance.Initiator.IsPlayerFaction)
            {
                return true;
            }
            if (Game.Instance.Player.IsInCombat && Main.Settings.OnlyOutOfCombat)
            {
                return true;
            }
            if (__instance.EnsureSuccess.HasValue)
            {
                return true;
            }
            int action = __instance.StatType switch
            {
                StatType.WarhammerWeaponSkill => Main.Settings.WarhammerWeaponSkill,
                StatType.WarhammerBallisticSkill => Main.Settings.WarhammerBallisticSkill,
                StatType.WarhammerStrength => Main.Settings.WarhammerStrength,
                StatType.WarhammerToughness => Main.Settings.WarhammerToughness,
                StatType.WarhammerAgility => Main.Settings.WarhammerAgility,
                StatType.WarhammerIntelligence => Main.Settings.WarhammerIntelligence,
                StatType.WarhammerPerception => Main.Settings.WarhammerPerception,
                StatType.WarhammerWillpower => Main.Settings.WarhammerWillpower,
                StatType.WarhammerFellowship => Main.Settings.WarhammerFellowship,
                StatType.SkillAthletics => Main.Settings.SkillAthletics,
                StatType.SkillCarouse => Main.Settings.SkillCarouse,
                StatType.SkillDemolition => Main.Settings.SkillDemolition,
                StatType.SkillLogic => Main.Settings.SkillLogic,
                StatType.SkillLoreImperium => Main.Settings.SkillLoreImperium,
                StatType.SkillLoreWarp => Main.Settings.SkillLoreWarp,
                StatType.SkillLoreXenos => Main.Settings.SkillLoreXenos,
                StatType.SkillMedicae => Main.Settings.SkillMedicae,
                StatType.SkillTechUse => Main.Settings.SkillTechUse,
                StatType.SkillAwareness => Main.Settings.SkillAwareness,
                StatType.SkillCoercion => Main.Settings.SkillCoercion,
                StatType.SkillCommerce => Main.Settings.SkillCommerce,
                StatType.SkillPersuasion => Main.Settings.SkillPersuasion,
                StatType.CheckBluff => Main.Settings.SkillPersuasion,
                StatType.CheckDiplomacy => Main.Settings.SkillPersuasion,
                StatType.CheckIntimidate => Main.Settings.SkillCoercion,
                _ => 0,
            };
            if (action == 0) return true;
            int rollValue = action switch
            {
                1 => 50,
                2 => 33,
                3 => 25,
                4 => 10,
                5 => 1,
                _ => 0
            };
            if (rollValue == 0) return true;
            __result = RuleRollChance.FromInt(__instance.Initiator, __instance.GetSuccessChance(), rollValue, __instance.StatType);
            return false;
        }
    }
}
