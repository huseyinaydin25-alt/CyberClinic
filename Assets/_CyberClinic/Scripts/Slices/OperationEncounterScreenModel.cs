namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterIdentitySection
    {
        public OperationEncounterIdentitySection(string encounterId, string contentVersion, string sourceId)
        {
            EncounterId = encounterId;
            ContentVersion = contentVersion;
            SourceId = sourceId;
        }

        public string EncounterId { get; }
        public string ContentVersion { get; }
        public string SourceId { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(EncounterId) &&
                   !string.IsNullOrWhiteSpace(ContentVersion) &&
                   !string.IsNullOrWhiteSpace(SourceId);
        }
    }

    public readonly struct OperationEncounterSubjectSection
    {
        public OperationEncounterSubjectSection(string participantId, string archetypeId, int stabilityScore)
        {
            ParticipantId = participantId;
            ArchetypeId = archetypeId;
            StabilityScore = stabilityScore;
        }

        public string ParticipantId { get; }
        public string ArchetypeId { get; }
        public int StabilityScore { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ParticipantId) &&
                   !string.IsNullOrWhiteSpace(ArchetypeId) &&
                   StabilityScore >= 0;
        }
    }

    public readonly struct OperationEncounterActionSection
    {
        public OperationEncounterActionSection(string procedureId, string specialtyId, int difficultyScore)
        {
            ProcedureId = procedureId;
            SpecialtyId = specialtyId;
            DifficultyScore = difficultyScore;
        }

        public string ProcedureId { get; }
        public string SpecialtyId { get; }
        public int DifficultyScore { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ProcedureId) &&
                   !string.IsNullOrWhiteSpace(SpecialtyId) &&
                   DifficultyScore >= 0;
        }
    }

    public readonly struct OperationEncounterRiskSection
    {
        public OperationEncounterRiskSection(string riskTierId, int baseRiskScore, int minimumRecommendedPower)
        {
            RiskTierId = riskTierId;
            BaseRiskScore = baseRiskScore;
            MinimumRecommendedPower = minimumRecommendedPower;
        }

        public string RiskTierId { get; }
        public int BaseRiskScore { get; }
        public int MinimumRecommendedPower { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(RiskTierId) &&
                   BaseRiskScore >= 0 &&
                   MinimumRecommendedPower >= 0;
        }
    }

    public readonly struct OperationEncounterRewardSection
    {
        public OperationEncounterRewardSection(string rewardTableId, int baseCreditReward, int baseReputationReward)
        {
            RewardTableId = rewardTableId;
            BaseCreditReward = baseCreditReward;
            BaseReputationReward = baseReputationReward;
        }

        public string RewardTableId { get; }
        public int BaseCreditReward { get; }
        public int BaseReputationReward { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(RewardTableId) &&
                   BaseCreditReward >= 0 &&
                   BaseReputationReward >= 0;
        }
    }

    public readonly struct OperationEncounterScreenModel
    {
        public OperationEncounterScreenModel(
            OperationEncounterIdentitySection identity,
            OperationEncounterSubjectSection subject,
            OperationEncounterActionSection action,
            OperationEncounterRiskSection risk,
            OperationEncounterRewardSection reward)
        {
            Identity = identity;
            Subject = subject;
            Action = action;
            Risk = risk;
            Reward = reward;
        }

        public OperationEncounterIdentitySection Identity { get; }
        public OperationEncounterSubjectSection Subject { get; }
        public OperationEncounterActionSection Action { get; }
        public OperationEncounterRiskSection Risk { get; }
        public OperationEncounterRewardSection Reward { get; }

        public bool IsValid()
        {
            return Identity.IsValid() &&
                   Subject.IsValid() &&
                   Action.IsValid() &&
                   Risk.IsValid() &&
                   Reward.IsValid();
        }
    }
}
