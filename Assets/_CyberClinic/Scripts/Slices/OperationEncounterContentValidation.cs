using System.Collections.Generic;

namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterContentValidationIssue
    {
        public OperationEncounterContentValidationIssue(string encounterId, string issueCode)
        {
            EncounterId = encounterId;
            IssueCode = issueCode;
        }

        public string EncounterId { get; }
        public string IssueCode { get; }
    }

    public readonly struct OperationEncounterContentValidationResult
    {
        public OperationEncounterContentValidationResult(
            bool isValid,
            int checkedCount,
            IReadOnlyList<OperationEncounterContentValidationIssue> issues)
        {
            IsValid = isValid;
            CheckedCount = checkedCount;
            Issues = issues;
        }

        public bool IsValid { get; }
        public int CheckedCount { get; }
        public IReadOnlyList<OperationEncounterContentValidationIssue> Issues { get; }
        public int IssueCount => Issues == null ? 0 : Issues.Count;
    }

    public static class OperationEncounterContentValidator
    {
        public static OperationEncounterContentValidationResult Validate(IReadOnlyList<OperationEncounterDefinition> definitions)
        {
            var issues = new List<OperationEncounterContentValidationIssue>();

            if (definitions == null || definitions.Count == 0)
            {
                issues.Add(new OperationEncounterContentValidationIssue(string.Empty, "definitions_missing"));
                return new OperationEncounterContentValidationResult(false, 0, issues);
            }

            var seenIds = new HashSet<string>();

            for (int i = 0; i < definitions.Count; i++)
            {
                var definition = definitions[i];
                var encounterId = definition.EncounterId ?? string.Empty;

                if (!definition.IsValid())
                {
                    issues.Add(new OperationEncounterContentValidationIssue(encounterId, "definition_invalid"));
                    continue;
                }

                if (!seenIds.Add(definition.EncounterId))
                {
                    issues.Add(new OperationEncounterContentValidationIssue(definition.EncounterId, "duplicate_encounter_id"));
                }

                if (definition.RiskProfile.MinimumRecommendedPower < definition.Procedure.DifficultyScore)
                {
                    issues.Add(new OperationEncounterContentValidationIssue(definition.EncounterId, "recommended_power_below_difficulty"));
                }

                if (definition.RewardProfile.BaseCreditReward == 0 && definition.RewardProfile.BaseReputationReward == 0)
                {
                    issues.Add(new OperationEncounterContentValidationIssue(definition.EncounterId, "reward_profile_empty"));
                }
            }

            return new OperationEncounterContentValidationResult(issues.Count == 0, definitions.Count, issues);
        }
    }
}
