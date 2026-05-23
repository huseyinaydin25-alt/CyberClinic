using System;
using CyberClinic.Core;
using CyberClinic.Patients;

namespace CyberClinic.Procedures
{
    /// <summary>
    /// Input DTO for OperationCalculator (Milestone 5). References content by id, not ScriptableObject instances.
    /// </summary>
    [Serializable]
    public class OperationInput
    {
        public ProcedurePlan Plan;
        public GeneratedPatient Patient;
        public string SelectedImplantId;
        public string SelectedProcedureId;
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
