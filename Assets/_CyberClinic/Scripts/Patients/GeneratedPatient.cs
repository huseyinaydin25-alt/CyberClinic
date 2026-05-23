using System;
using CyberClinic.Core;

namespace CyberClinic.Patients
{
    /// <summary>
    /// Runtime patient instance composed from generation components.
    /// Generation logic is implemented in a later milestone; this type is the data contract only.
    /// </summary>
    [Serializable]
    public class GeneratedPatient
    {
        public Guid InstanceId = Guid.NewGuid();
        public int PatientSeed;
        public SeedContext GenerationContext;

        public string ArchetypeId;
        public string MotivationId;
        public string BodyProblemId;
        public BodySlot BodyProblemSlot;
        public string RequestTypeId;
        public BodySlot RequestedUpgradeSlot;

        public PatientBudgetProfile Budget = new PatientBudgetProfile();
        public PatientRiskProfile Risk = new PatientRiskProfile();
        public PatientUrgencyProfile Urgency = new PatientUrgencyProfile();
        public PatientKnownInfo Known = new PatientKnownInfo();
        public PatientHiddenInfo Hidden = new PatientHiddenInfo();

        public string VisualTraitId;
        public string DialogueToneId;
        public PatientLegalStatus LegalStatus;
    }
}
