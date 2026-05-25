using CyberClinic.Core;

namespace CyberClinic.Patients
{
    /// <summary>Filtered pools and deterministic random state for one generation pass.</summary>
    public sealed class PatientGenerationContext
    {
        public SeedContext SeedContext;
        public int PatientSeed;
        public CyberClinicRandom Random;
        public PatientGenerationConfig Config;

        public PatientArchetypeData[] Archetypes;
        public PatientMotivationData[] Motivations;
        public PatientHiddenConditionData[] HiddenConditions;
        public PatientVisualTraitData[] VisualTraits;
        public PatientDialogueToneData[] DialogueTones;
        public PatientRequestTypeData[] RequestTypes;
    }
}
