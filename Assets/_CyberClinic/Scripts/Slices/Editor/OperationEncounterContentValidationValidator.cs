#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterContentValidationValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run M1.R Content Validation Debug")]
        public static void RunDebug()
        {
            var source = new OperationEncounterDebugContentSource();
            var loadResult = OperationEncounterContentLoader.Load(source);
            var validResult = OperationEncounterContentValidator.Validate(loadResult.Definitions);

            var validContentOk =
                validResult.IsValid &&
                validResult.CheckedCount == 1 &&
                validResult.IssueCount == 0;

            var missingResult = OperationEncounterContentValidator.Validate(null);
            var missingOk =
                !missingResult.IsValid &&
                missingResult.CheckedCount == 0 &&
                missingResult.IssueCount == 1 &&
                missingResult.Issues[0].IssueCode == "definitions_missing";

            var duplicateDefinitions = new[]
            {
                loadResult.Definitions[0],
                loadResult.Definitions[0]
            };
            var duplicateResult = OperationEncounterContentValidator.Validate(duplicateDefinitions);
            var duplicateOk =
                !duplicateResult.IsValid &&
                duplicateResult.CheckedCount == 2 &&
                HasIssue(duplicateResult, "duplicate_encounter_id");

            var weakPowerDefinition = new OperationEncounterDefinition(
                "debug_encounter_weak_power",
                "debug.v1",
                new OperationEncounterParticipantDefinition("participant.weak", "archetype.test", 10),
                new OperationEncounterProcedureDefinition("procedure.hard", "specialty.test", 90),
                new OperationEncounterRiskProfile(20, 10, "risk.high"),
                new OperationEncounterRewardProfile("reward_table.test", 10, 1));
            var weakPowerResult = OperationEncounterContentValidator.Validate(new[] { weakPowerDefinition });
            var weakPowerOk =
                !weakPowerResult.IsValid &&
                weakPowerResult.CheckedCount == 1 &&
                HasIssue(weakPowerResult, "recommended_power_below_difficulty");

            if (!validContentOk || !missingOk || !duplicateOk || !weakPowerOk)
            {
                Debug.LogWarning(
                    "OperationEncounterContentValidationDebug failed" +
                    "\nvalidContentOk=" + validContentOk +
                    "\nmissingOk=" + missingOk +
                    "\nduplicateOk=" + duplicateOk +
                    "\nweakPowerOk=" + weakPowerOk +
                    "\nvalidIssueCount=" + validResult.IssueCount +
                    "\nmissingIssueCount=" + missingResult.IssueCount +
                    "\nduplicateIssueCount=" + duplicateResult.IssueCount +
                    "\nweakPowerIssueCount=" + weakPowerResult.IssueCount);
                return;
            }

            Debug.Log(
                "OperationEncounterContentValidationDebug OK" +
                "\nvalidContent=True" +
                "\nmissingDefinitionsBlocked=True" +
                "\nduplicateEncounterBlocked=True" +
                "\nweakPowerWarning=True" +
                "\ncheckedCount=" + validResult.CheckedCount +
                "\nissueCount=" + validResult.IssueCount +
                "\nadminPublishSafetyReady=True" +
                "\nuiBinding=operation_encounter_content_validation_ready");
        }

        static bool HasIssue(OperationEncounterContentValidationResult result, string issueCode)
        {
            for (int i = 0; i < result.IssueCount; i++)
            {
                if (result.Issues[i].IssueCode == issueCode)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
#endif
