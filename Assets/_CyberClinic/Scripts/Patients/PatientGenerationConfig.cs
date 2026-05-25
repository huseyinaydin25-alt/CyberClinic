using System;
using CyberClinic.Core;
using CyberClinic.Cosmetics;

namespace CyberClinic.Patients
{
    /// <summary>Runtime tuning for procedural patient generation (not a ScriptableObject).</summary>
    [Serializable]
    public class PatientGenerationConfig
    {
        public bool AllowGrayMarket = true;
        public bool AllowIllegal;
        public int MinBudget = 150;
        public int MaxBudget = 900;
        public PatientUrgencyLevel MinUrgency = PatientUrgencyLevel.Low;
        public PatientUrgencyLevel MaxUrgency = PatientUrgencyLevel.High;
        public RangeFloat BasePanicRange = new RangeFloat(10f, 45f);
        public RangeFloat BaseNeuralStabilityRange = new RangeFloat(0.3f, 0.85f);
        public RangeFloat BaseCyberToxResistanceRange = new RangeFloat(0.3f, 0.85f);
        public bool TutorialSafeMode;
        public ClinicTier TargetClinicTier = ClinicTier.BackAlley;
        public int MaxHiddenConditions = 1;
        public float SlotConflictChance = 0.25f;
    }
}
