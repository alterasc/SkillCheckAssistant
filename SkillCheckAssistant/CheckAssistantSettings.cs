using UnityModManagerNet;

namespace SkillCheckAssistant
{
    public class CheckAssistantSettings : UnityModManager.ModSettings
    {
        public int SkillAthletics = 0;
        public int SkillCarouse = 0;
        public int SkillDemolition = 0;
        public int SkillLogic = 0;
        public int SkillLoreImperium = 0;
        public int SkillLoreWarp = 0;
        public int SkillLoreXenos = 0;
        public int SkillMedicae = 0;
        public int SkillTechUse = 0;
        public int SkillAwareness = 0;
        public int SkillCoercion = 0;
        public int SkillCommerce = 0;
        public int SkillPersuasion = 0;

        public virtual void Save(UnityModManager.ModEntry modEntry) => Save(this, modEntry);
    }
}
