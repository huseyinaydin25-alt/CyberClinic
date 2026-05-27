using CyberClinic.Core;
using CyberClinic.Economy;
using CyberClinic.Patients;
using CyberClinic.Procedures;
using CyberClinic.Save;

namespace CyberClinic.Slices
{
    public static class PatientPuzzleSliceRunner
    {
        public static PatientPuzzleSliceReport RunDebugSlice()
        {
            var patient = CreatePatient();
            var options = CreateOptions();
            var selected = options[1];

            var input = CreateOperationInput(patient, selected);
            var preview = OperationCalculator.Preview(input);
            var commit = OperationCalculator.Commit(input);

            var startEconomy = new ClinicEconomyState
            {
                Credits = 500,
                Reputation = 40,
                DayIndex = 5
            };

            var deltas = new[]
            {
                new EconomyDelta(210 - selected.Price, 5, "slice.operation.result")
            };
            var report = DayReportBuilder.Build(startEconomy, deltas, 1, 1, 0);

            var save = new SaveGameData
            {
                CurrentDayIndex = 6,
                Economy = new ClinicEconomyState
                {
                    Credits = report.EndingCredits,
                    Reputation = report.EndingReputation,
                    DayIndex = 6
                },
                OwnedCosmeticIds = new[] { "test_cosmetic_a" },
                ActiveClinicThemeId = "test_theme_a"
            };
            var json = SaveSerializer.ToJson(save);

            return new PatientPuzzleSliceReport
            {
                PatientId = patient.ArchetypeId,
                PatientSeed = patient.PatientSeed,
                SelectedImplantId = selected.ImplantId,
                SelectedProcedureId = input.SelectedProcedureId,
                PreviewSuccessChance = preview.SuccessChance.Value,
                CommitSuccessChance = commit.SuccessChance.Value,
                RiskBand = commit.RiskBand.ToString(),
                OutcomeType = commit.OutcomeType.ToString(),
                StartingCredits = report.StartingCredits,
                EndingCredits = report.EndingCredits,
                StartingReputation = report.StartingReputation,
                EndingReputation = report.EndingReputation,
                VisualCueId = "test_cue_result_reveal",
                AudioCueId = "test_audio_operation_success",
                SaveSummary = "jsonLength=" + json.Length
            };
        }

        static GeneratedPatient CreatePatient()
        {
            return new GeneratedPatient
            {
                PatientSeed = 82115621,
                ArchetypeId = "test_street_netrunner",
                MotivationId = "test_urgent_fix",
                RequestTypeId = "test_optic_tune",
                RequestedUpgradeSlot = BodySlot.Head,
                BodyProblemSlot = BodySlot.Skin,
                BodyProblemId = "body_problem.skin",
                VisualTraitId = "test_chrome_jaw",
                DialogueToneId = "test_nervous",
                Risk = new PatientRiskProfile
                {
                    NeuralStability = new Percentage01(0.431f),
                    CyberToxResistance = new Percentage01(0.841f),
                    PanicNumeric = 29
                }
            };
        }

        static PatientPuzzleImplantOption[] CreateOptions()
        {
            return new[]
            {
                new PatientPuzzleImplantOption { ImplantId = "test_implant_budget_eye", Slot = BodySlot.Head, Price = 90, CompatibilityScore = 0.05f, LabelKey = "implant.test.budget_eye.name" },
                new PatientPuzzleImplantOption { ImplantId = "test_implant_optic_tune", Slot = BodySlot.Head, Price = 120, CompatibilityScore = 0.15f, LabelKey = "implant.test.optic_tune.name" },
                new PatientPuzzleImplantOption { ImplantId = "test_implant_overclock_eye", Slot = BodySlot.Head, Price = 190, CompatibilityScore = -0.05f, LabelKey = "implant.test.overclock_eye.name" }
            };
        }

        static OperationInput CreateOperationInput(GeneratedPatient patient, PatientPuzzleImplantOption selected)
        {
            var operationSeed = new SeedContext(84921, 3, 0).ToOperationSeed(0);
            return new OperationInput
            {
                Plan = new ProcedurePlan
                {
                    ProcedureId = "test_proc_micro_install",
                    ImplantId = selected.ImplantId,
                    BaseSuccess = 0.82f,
                    ProcedureDifficulty = 0.12f,
                    PreparationBonus = 0.02f,
                    OperationSeed = operationSeed
                },
                Patient = patient,
                SelectedImplantId = selected.ImplantId,
                SelectedProcedureId = "test_proc_micro_install",
                ClinicSkillBonus = 0.03f,
                EquipmentBonus = 0.05f,
                ImplantCompatibilityScore = selected.CompatibilityScore,
                HiddenConditionPenalty = 0.05f,
                IllegalImplantRisk = 0f,
                CyberToxPressure = new Percentage01(0.019f),
                NeuralLoadPressure = new Percentage01(0.108f),
                BodyStress = new Percentage01(0.04f),
                OperationSeed = operationSeed
            };
        }
    }
}
