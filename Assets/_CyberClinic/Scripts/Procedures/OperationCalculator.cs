using System;
using CyberClinic.Core;

namespace CyberClinic.Procedures
{
    /// <summary>Pure deterministic operation math. No UI, save, economy, reputation, VFX, or audio side effects.</summary>
    public static class OperationCalculator
    {
        const float MinVariance = -0.05f;
        const float MaxVariance = 0.05f;
        const float PanicScale = 0.20f;

        public static OperationResult Preview(OperationInput input)
        {
            return Calculate(input, false);
        }

        public static OperationResult Commit(OperationInput input)
        {
            return Calculate(input, true);
        }

        static OperationResult Calculate(OperationInput input, bool commit)
        {
            if (input == null)
            {
                return Failed(0, "math.term.error.null_input");
            }

            var plan = input.Plan;
            var patient = input.Patient;
            var baseSuccess = plan != null ? Clamp01(plan.BaseSuccess) : 0f;
            var procedureDifficulty = plan != null ? Math.Max(0f, plan.ProcedureDifficulty) : 0f;
            var preparationBonus = plan != null ? Math.Max(0f, plan.PreparationBonus) : 0f;
            var panicPenalty = patient != null ? (Math.Clamp(patient.Risk.PanicNumeric, 0, 100) / 100f) * PanicScale : 0f;
            var operationSeed = ResolveOperationSeed(input);
            var variance = commit ? new CyberClinicRandom(operationSeed).NextFloat(MinVariance, MaxVariance) : 0f;

            var raw =
                baseSuccess +
                input.ClinicSkillBonus +
                input.EquipmentBonus +
                preparationBonus +
                input.ImplantCompatibilityScore -
                procedureDifficulty -
                input.CyberToxPressure.Value -
                input.NeuralLoadPressure.Value -
                input.BodyStress.Value -
                input.HiddenConditionPenalty -
                panicPenalty -
                input.IllegalImplantRisk +
                variance;

            var successChance = new Percentage01(raw);
            var riskBand = ResolveRiskBand(successChance.Value);
            var outcome = commit
                ? ResolveOutcome(successChance.Value, riskBand, operationSeed)
                : OperationOutcomeType.PreviewOnly;

            return new OperationResult
            {
                Success = true,
                SuccessChance = successChance,
                RiskBand = riskBand,
                OutcomeType = outcome,
                OperationSeed = operationSeed,
                RawScore = raw,
                RandomVariance = variance,
                Breakdown = new[]
                {
                    Entry("math.term.base_success", baseSuccess, 0),
                    Entry("math.term.clinic_skill_bonus", input.ClinicSkillBonus, 10),
                    Entry("math.term.equipment_bonus", input.EquipmentBonus, 20),
                    Entry("math.term.preparation_bonus", preparationBonus, 30),
                    Entry("math.term.implant_compatibility", input.ImplantCompatibilityScore, 40),
                    Entry("math.term.procedure_difficulty", -procedureDifficulty, 50),
                    Entry("math.term.cybertox_pressure", -input.CyberToxPressure.Value, 60),
                    Entry("math.term.neural_load_pressure", -input.NeuralLoadPressure.Value, 70),
                    Entry("math.term.body_stress", -input.BodyStress.Value, 80),
                    Entry("math.term.hidden_condition_penalty", -input.HiddenConditionPenalty, 90),
                    Entry("math.term.patient_panic_penalty", -panicPenalty, 100),
                    Entry("math.term.illegal_implant_risk", -input.IllegalImplantRisk, 110),
                    Entry("math.term.seeded_random_variance", variance, 120)
                }
            };
        }

        static OperationOutcomeType ResolveOutcome(float successChance, OperationRiskBand riskBand, int operationSeed)
        {
            var roll = new CyberClinicRandom(CyberClinicRandom.CombineSeed(operationSeed, 719)).NextFloat();
            if (roll <= successChance)
            {
                return successChance >= 0.85f && roll <= 0.10f
                    ? OperationOutcomeType.CriticalSuccess
                    : OperationOutcomeType.StableSuccess;
            }

            if (roll <= successChance + 0.10f)
            {
                return OperationOutcomeType.UnstableSuccess;
            }

            return riskBand == OperationRiskBand.Critical && roll >= 0.90f
                ? OperationOutcomeType.Catastrophe
                : OperationOutcomeType.Failure;
        }

        static OperationRiskBand ResolveRiskBand(float successChance)
        {
            if (successChance >= 0.85f) return OperationRiskBand.Safe;
            if (successChance >= 0.70f) return OperationRiskBand.Stable;
            if (successChance >= 0.50f) return OperationRiskBand.Uncertain;
            if (successChance >= 0.30f) return OperationRiskBand.Dangerous;
            return OperationRiskBand.Critical;
        }

        static int ResolveOperationSeed(OperationInput input)
        {
            if (input.OperationSeed != 0)
            {
                return input.OperationSeed;
            }

            return input.Plan != null ? input.Plan.OperationSeed : 0;
        }

        static OperationBreakdownEntry Entry(string key, float value, int sortOrder) =>
            new OperationBreakdownEntry(key, value, sortOrder);

        static float Clamp01(float value) => Math.Clamp(value, 0f, 1f);

        static OperationResult Failed(int operationSeed, string termKey) => new OperationResult
        {
            Success = false,
            SuccessChance = Percentage01.Zero,
            RiskBand = OperationRiskBand.Critical,
            OutcomeType = OperationOutcomeType.PreviewOnly,
            OperationSeed = operationSeed,
            RawScore = 0f,
            RandomVariance = 0f,
            Breakdown = new[] { Entry(termKey, 0f, 0) }
        };
    }
}
