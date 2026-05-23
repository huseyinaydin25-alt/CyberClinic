using System;
using CyberClinic.Core;
using CyberClinic.Implants;
using CyberClinic.Patients;

namespace CyberClinic.Procedures
{
    /// <summary>
    /// Immutable input DTO for OperationCalculator (Milestone 5). Pure data only.
    /// </summary>
    [Serializable]
    public class OperationInput
    {
        public ProcedurePlan Plan;
        public GeneratedPatient Patient;
        public ImplantData SelectedImplant;
        public ProcedureData SelectedProcedure;
        public float ClinicSkillBonus;
        public float EquipmentBonus;
        public float ImplantCompatibilityScore;
        public float HiddenConditionPenalty;
        public float IllegalImplantRisk;
        public Percentage01 CyberToxPressure;
        public Percentage01 NeuralLoadPressure;
        public Percentage01 BodyStress;
        public int OperationSeed;
    }
}
