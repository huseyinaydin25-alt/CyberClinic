namespace CyberClinic.Slices
{
    public static class OperationEncounterScreenModelBuilder
    {
        public static OperationEncounterScreenModel FromDefinition(
            OperationEncounterDefinition definition,
            string sourceId)
        {
            return new OperationEncounterScreenModel(
                new OperationEncounterIdentitySection(
                    definition.EncounterId,
                    definition.ContentVersion,
                    sourceId),
                new OperationEncounterSubjectSection(
                    definition.Participant.ParticipantId,
                    definition.Participant.ArchetypeId,
                    definition.Participant.BaseStabilityScore),
                new OperationEncounterActionSection(
                    definition.Procedure.ProcedureId,
                    definition.Procedure.SpecialtyId,
                    definition.Procedure.DifficultyScore),
                new OperationEncounterRiskSection(
                    definition.RiskProfile.RiskTierId,
                    definition.RiskProfile.BaseRiskScore,
                    definition.RiskProfile.MinimumRecommendedPower),
                new OperationEncounterRewardSection(
                    definition.RewardProfile.RewardTableId,
                    definition.RewardProfile.BaseCreditReward,
                    definition.RewardProfile.BaseReputationReward));
        }

        public static OperationEncounterScreenModel FromContentSource(
            IOperationEncounterContentSource source,
            string encounterId)
        {
            var loadResult = OperationEncounterContentLoader.Load(source);
            var registry = new OperationEncounterDefinitionRegistry(loadResult.Definitions);

            if (!registry.TryGet(encounterId, out var definition))
            {
                return default;
            }

            return FromDefinition(definition, loadResult.SourceId);
        }
    }
}
