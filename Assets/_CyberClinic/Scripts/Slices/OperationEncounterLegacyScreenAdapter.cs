namespace CyberClinic.Slices
{
    public static class OperationEncounterLegacyScreenAdapter
    {
        public static PatientPuzzleSliceScreenModel ToLegacyScreenModel(OperationEncounterDefinition definition)
        {
            var participantSeed = StablePositiveSeed(definition.Participant.ParticipantId);
            var previewChance = CalculatePreviewChance(definition);
            var executeChance = CalculateExecuteChance(previewChance, definition);
            var outcomeType = ResolveOutcomeType(previewChance, executeChance);

            return new PatientPuzzleSliceScreenModel(
                new PatientDossierSection(
                    definition.Participant.ParticipantId,
                    participantSeed),
                new ProcedureDecisionSection(
                    definition.Participant.ArchetypeId,
                    definition.Procedure.ProcedureId),
                new RiskAnalysisSection(
                    previewChance,
                    executeChance,
                    definition.RiskProfile.RiskTierId,
                    outcomeType),
                new OperationResultSection(
                    500,
                    500 + definition.RewardProfile.BaseCreditReward,
                    40,
                    40 + definition.RewardProfile.BaseReputationReward,
                    outcomeType,
                    "definitionId=" + definition.EncounterId + ";contentVersion=" + definition.ContentVersion),
                new ActionFeedbackSection(
                    "visual." + definition.RiskProfile.RiskTierId,
                    "audio." + outcomeType));
        }

        static int StablePositiveSeed(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 1;
            }

            unchecked
            {
                var hash = 17;
                for (int i = 0; i < value.Length; i++)
                {
                    hash = hash * 31 + value[i];
                }

                if (hash == int.MinValue)
                {
                    return int.MaxValue;
                }

                return hash < 0 ? -hash : hash;
            }
        }

        static float CalculatePreviewChance(OperationEncounterDefinition definition)
        {
            var stability = definition.Participant.BaseStabilityScore;
            var requiredPower = definition.RiskProfile.MinimumRecommendedPower;
            var difficulty = definition.Procedure.DifficultyScore;
            var risk = definition.RiskProfile.BaseRiskScore;

            var raw = 0.50f + ((stability + requiredPower) - (difficulty + risk)) / 300f;
            return Clamp01Range(raw);
        }

        static float CalculateExecuteChance(float previewChance, OperationEncounterDefinition definition)
        {
            var executionBonus = definition.RewardProfile.BaseReputationReward / 500f;
            return Clamp01Range(previewChance + executionBonus);
        }

        static float Clamp01Range(float value)
        {
            if (value < 0.05f)
            {
                return 0.05f;
            }

            if (value > 0.95f)
            {
                return 0.95f;
            }

            return value;
        }

        static string ResolveOutcomeType(float previewChance, float executeChance)
        {
            var average = (previewChance + executeChance) * 0.5f;
            if (average >= 0.75f)
            {
                return "outcome.strong_success";
            }

            if (average >= 0.55f)
            {
                return "outcome.stable_success";
            }

            if (average >= 0.35f)
            {
                return "outcome.uncertain";
            }

            return "outcome.high_risk";
        }
    }
}
