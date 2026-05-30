namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterParticipantDefinition
    {
        public OperationEncounterParticipantDefinition(string participantId, string archetypeId, int baseStabilityScore)
        {
            ParticipantId = participantId;
            ArchetypeId = archetypeId;
            BaseStabilityScore = baseStabilityScore;
        }

        public string ParticipantId { get; }
        public string ArchetypeId { get; }
        public int BaseStabilityScore { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ParticipantId) &&
                   !string.IsNullOrWhiteSpace(ArchetypeId) &&
                   BaseStabilityScore >= 0;
        }
    }

    public readonly struct OperationEncounterProcedureDefinition
    {
        public OperationEncounterProcedureDefinition(string procedureId, string specialtyId, int difficultyScore)
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

    public readonly struct OperationEncounterRiskProfile
    {
        public OperationEncounterRiskProfile(int baseRiskScore, int minimumRecommendedPower, string riskTierId)
        {
            BaseRiskScore = baseRiskScore;
            MinimumRecommendedPower = minimumRecommendedPower;
            RiskTierId = riskTierId;
        }

        public int BaseRiskScore { get; }
        public int MinimumRecommendedPower { get; }
        public string RiskTierId { get; }

        public bool IsValid()
        {
            return BaseRiskScore >= 0 &&
                   MinimumRecommendedPower >= 0 &&
                   !string.IsNullOrWhiteSpace(RiskTierId);
        }
    }

    public readonly struct OperationEncounterRewardProfile
    {
        public OperationEncounterRewardProfile(string rewardTableId, int baseCreditReward, int baseReputationReward)
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

    public readonly struct OperationEncounterDefinition
    {
        public OperationEncounterDefinition(
            string encounterId,
            string contentVersion,
            OperationEncounterParticipantDefinition participant,
            OperationEncounterProcedureDefinition procedure,
            OperationEncounterRiskProfile riskProfile,
            OperationEncounterRewardProfile rewardProfile)
        {
            EncounterId = encounterId;
            ContentVersion = contentVersion;
            Participant = participant;
            Procedure = procedure;
            RiskProfile = riskProfile;
            RewardProfile = rewardProfile;
        }

        public string EncounterId { get; }
        public string ContentVersion { get; }
        public OperationEncounterParticipantDefinition Participant { get; }
        public OperationEncounterProcedureDefinition Procedure { get; }
        public OperationEncounterRiskProfile RiskProfile { get; }
        public OperationEncounterRewardProfile RewardProfile { get; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(EncounterId) &&
                   !string.IsNullOrWhiteSpace(ContentVersion) &&
                   Participant.IsValid() &&
                   Procedure.IsValid() &&
                   RiskProfile.IsValid() &&
                   RewardProfile.IsValid();
        }
    }
}
