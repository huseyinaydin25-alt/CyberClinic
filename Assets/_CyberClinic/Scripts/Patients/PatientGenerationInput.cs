using System;
using CyberClinic.Core;

namespace CyberClinic.Patients
{
    /// <summary>Inputs for a single deterministic patient generation call.</summary>
    [Serializable]
    public class PatientGenerationInput
    {
        public SeedContext SeedContext;
        public PatientGenerationConfig Config = new PatientGenerationConfig();
        public PatientArchetypeData[] Archetypes = Array.Empty<PatientArchetypeData>();
        public PatientMotivationData[] Motivations = Array.Empty<PatientMotivationData>();
        public PatientHiddenConditionData[] HiddenConditions = Array.Empty<PatientHiddenConditionData>();
        public PatientVisualTraitData[] VisualTraits = Array.Empty<PatientVisualTraitData>();
        public PatientDialogueToneData[] DialogueTones = Array.Empty<PatientDialogueToneData>();
        public PatientRequestTypeData[] RequestTypes = Array.Empty<PatientRequestTypeData>();
    }
}
