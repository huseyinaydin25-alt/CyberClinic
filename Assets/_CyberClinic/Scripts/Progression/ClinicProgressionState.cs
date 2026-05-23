using System;
using CyberClinic.Cosmetics;

namespace CyberClinic.Progression
{
    [Serializable]
    public class ClinicProgressionState
    {
        public ClinicTier UnlockedTier = ClinicTier.BackAlley;
        public float ClinicSkillBonus;
        public float EquipmentBonus;
        public string[] UnlockedProcedureIds = Array.Empty<string>();
    }
}
