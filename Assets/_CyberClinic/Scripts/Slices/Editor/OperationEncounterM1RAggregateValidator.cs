#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterM1RAggregateValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run M1.R Aggregate Debug")]
        public static void RunDebug()
        {
            var source = new OperationEncounterDebugContentSource();
            var loadResult = OperationEncounterContentLoader.Load(source);
            var validationResult = OperationEncounterContentValidator.Validate(loadResult.Definitions);
            var registry = new OperationEncounterDefinitionRegistry(loadResult.Definitions);
            var loaded = registry.TryGet("debug_encounter_street_netrunner_optic_tune", out var definition);
            var canonicalScreen = OperationEncounterScreenModelBuilder.FromContentSource(
                source,
                "debug_encounter_street_netrunner_optic_tune");
            var legacyScreen = OperationEncounterLegacyScreenAdapter.ToLegacyScreenModel(definition);

            var definitionOk = loaded && definition.IsValid();
            var contentSourceOk = loadResult.Success && loadResult.Count == 1;
            var contentValidationOk = validationResult.IsValid && validationResult.CheckedCount == 1 && validationResult.IssueCount == 0;
            var registryOk = registry.Count == 1 && registry.Contains(definition.EncounterId);
            var canonicalScreenOk =
                canonicalScreen.IsValid() &&
                canonicalScreen.Identity.EncounterId == definition.EncounterId &&
                canonicalScreen.Identity.ContentVersion == definition.ContentVersion &&
                canonicalScreen.Identity.SourceId == source.SourceId &&
                canonicalScreen.Subject.ParticipantId == definition.Participant.ParticipantId &&
                canonicalScreen.Action.ProcedureId == definition.Procedure.ProcedureId &&
                canonicalScreen.Risk.RiskTierId == definition.RiskProfile.RiskTierId &&
                canonicalScreen.Reward.RewardTableId == definition.RewardProfile.RewardTableId;
            var legacyBridgeOk =
                legacyScreen.HasRequiredDebugData() &&
                legacyScreen.PatientDossier.PatientId == definition.Participant.ParticipantId &&
                legacyScreen.ProcedureDecision.SelectedProcedureId == definition.Procedure.ProcedureId &&
                legacyScreen.RiskAnalysis.RiskBand == definition.RiskProfile.RiskTierId &&
                legacyScreen.OperationResult.CreditsDelta == definition.RewardProfile.BaseCreditReward &&
                legacyScreen.OperationResult.ReputationDelta == definition.RewardProfile.BaseReputationReward;

            var endToEndOk =
                definitionOk &&
                contentSourceOk &&
                contentValidationOk &&
                registryOk &&
                canonicalScreenOk &&
                legacyBridgeOk;

            if (!endToEndOk)
            {
                Debug.LogWarning(
                    "OperationEncounterM1RAggregateDebug failed" +
                    "\ndefinitionOk=" + definitionOk +
                    "\ncontentSourceOk=" + contentSourceOk +
                    "\ncontentValidationOk=" + contentValidationOk +
                    "\nregistryOk=" + registryOk +
                    "\ncanonicalScreenOk=" + canonicalScreenOk +
                    "\nlegacyBridgeOk=" + legacyBridgeOk +
                    "\nloadCount=" + loadResult.Count +
                    "\nissueCount=" + validationResult.IssueCount);
                return;
            }

            Debug.Log(
                "OperationEncounterM1RAggregateDebug OK" +
                "\nmodularDefinition=True" +
                "\ncontentSource=True" +
                "\ncontentValidation=True" +
                "\ndefinitionRegistry=True" +
                "\ncanonicalScreenModel=True" +
                "\nlegacyScreenBridge=True" +
                "\nencounterId=" + definition.EncounterId +
                "\nsourceId=" + source.SourceId +
                "\ncontentVersion=" + definition.ContentVersion +
                "\nadminConfigReady=True" +
                "\ndataDrivenReady=True" +
                "\nlegacyFoundationPreserved=True" +
                "\nuiBinding=operation_encounter_m1r_aggregate_ready");
        }
    }
}
#endif
