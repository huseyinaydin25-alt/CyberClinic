#if UNITY_EDITOR
using CyberClinic.Core;
using CyberClinic.Patients;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Procedures.Editor
{
    /// <summary>Editor-only deterministic operation calculator smoke test (technical log output only).</summary>
    public static class OperationCalculatorDebugMenu
    {
        [MenuItem("Cyber Clinic/Procedures/Run Operation Calculator Debug")]
        public static void RunDebug()
        {
            var input = CreateDebugInput();
            var previewA = OperationCalculator.Preview(input);
            var previewB = OperationCalculator.Preview(input);
            var commitA = OperationCalculator.Commit(input);
            var commitB = OperationCalculator.Commit(input);

            var deterministic =
                previewA.SuccessChance.Value.Equals(previewB.SuccessChance.Value) &&
                previewA.RiskBand == previewB.RiskBand &&
                commitA.SuccessChance.Value.Equals(commitB.SuccessChance.Value) &&
                commitA.RiskBand == commitB.RiskBand &&
                commitA.OutcomeType == commitB.OutcomeType &&
                commitA.RandomVariance.Equals(commitB.RandomVariance);

            if (!deterministic)
            {
                Debug.LogWarning("OperationCalculatorDebug failed: deterministic outputs did not match.");
                return;
            }

            Debug.Log(
                "OperationCalculatorDebug OK\n" +
                $"operationSeed={commitA.OperationSeed}\n" +
                $"previewSuccessChance={previewA.SuccessChance.Value:F3}\n" +
                $"previewRiskBand={previewA.RiskBand}\n" +
                $"previewOutcome={previewA.OutcomeType}\n" +
                $"commitSuccessChance={commitA.SuccessChance.Value:F3}\n" +
                $"commitRiskBand={commitA.RiskBand}\n" +
                $"commitOutcome={commitA.OutcomeType}\n" +
                $"commitRandomVariance={commitA.RandomVariance:F3}\n" +
                $"rawScore={commitA.RawScore:F3}\n" +
                $"breakdownCount={commitA.Breakdown.Length}");
        }

        static OperationInput CreateDebugInput()
        {
            var patient = new GeneratedPatient
            {
                Risk = new PatientRiskProfile
                {
                    NeuralStability = new Percentage01(0.431f),
                    CyberToxResistance = new Percentage01(0.841f),
                    PanicNumeric = 29
                }
            };

            return new OperationInput
            {
                Plan = new ProcedurePlan
                {
                    ProcedureId = "test_proc_micro_install",
                    ImplantId = "test_implant_optic_tune",
                    BaseSuccess = 0.82f,
                    ProcedureDifficulty = 0.12f,
                    PreparationBonus = 0.02f,
                    OperationSeed = new SeedContext(84921, 3, 0).ToOperationSeed(0)
                },
                Patient = patient,
                SelectedImplantId = "test_implant_optic_tune",
                SelectedProcedureId = "test_proc_micro_install",
                ClinicSkillBonus = 0.03f,
                EquipmentBonus = 0.05f,
                ImplantCompatibilityScore = 0.15f,
                HiddenConditionPenalty = 0.05f,
                IllegalImplantRisk = 0f,
                CyberToxPressure = new Percentage01(0.019f),
                NeuralLoadPressure = new Percentage01(0.108f),
                BodyStress = new Percentage01(0.04f),
                OperationSeed = new SeedContext(84921, 3, 0).ToOperationSeed(0)
            };
        }
    }
}
#endif
