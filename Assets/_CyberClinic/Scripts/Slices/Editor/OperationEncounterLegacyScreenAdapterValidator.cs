#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterLegacyScreenAdapterValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run M1.R Legacy Screen Adapter Debug")]
        public static void RunDebug()
        {
            var source = new OperationEncounterDebugContentSource();
            var loadResult = OperationEncounterContentLoader.Load(source);
            var registry = new OperationEncounterDefinitionRegistry(loadResult.Definitions);
            var loaded = registry.TryGet("debug_encounter_street_netrunner_optic_tune", out var definition);
            var screenModel = OperationEncounterLegacyScreenAdapter.ToLegacyScreenModel(definition);

            var loadOk = loadResult.Success && loaded && definition.IsValid();
            var participantOk =
                screenModel.PatientDossier.PatientId == definition.Participant.ParticipantId &&
                screenModel.PatientDossier.PatientSeed > 0;
            var procedureOk =
                screenModel.ProcedureDecision.SelectedImplantId == definition.Participant.ArchetypeId &&
                screenModel.ProcedureDecision.SelectedProcedureId == definition.Procedure.ProcedureId;
            var riskOk =
                screenModel.RiskAnalysis.PreviewSuccessChance > 0f &&
                screenModel.RiskAnalysis.CommitSuccessChance >= screenModel.RiskAnalysis.PreviewSuccessChance &&
                screenModel.RiskAnalysis.RiskBand == definition.RiskProfile.RiskTierId &&
                !string.IsNullOrWhiteSpace(screenModel.RiskAnalysis.OutcomeType);
            var rewardOk =
                screenModel.OperationResult.StartingCredits == 500 &&
                screenModel.OperationResult.EndingCredits == 500 + definition.RewardProfile.BaseCreditReward &&
                screenModel.OperationResult.StartingReputation == 40 &&
                screenModel.OperationResult.EndingReputation == 40 + definition.RewardProfile.BaseReputationReward &&
                screenModel.OperationResult.SaveSummary.Contains(definition.EncounterId);
            var feedbackOk =
                screenModel.ActionFeedback.VisualCueId == "visual." + definition.RiskProfile.RiskTierId &&
                screenModel.ActionFeedback.AudioCueId == "audio." + screenModel.RiskAnalysis.OutcomeType;
            var requiredDataOk = screenModel.HasRequiredDebugData();

            if (!loadOk || !participantOk || !procedureOk || !riskOk || !rewardOk || !feedbackOk || !requiredDataOk)
            {
                Debug.LogWarning(
                    "OperationEncounterLegacyScreenAdapterDebug failed" +
                    "\nloadOk=" + loadOk +
                    "\nparticipantOk=" + participantOk +
                    "\nprocedureOk=" + procedureOk +
                    "\nriskOk=" + riskOk +
                    "\nrewardOk=" + rewardOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\nrequiredDataOk=" + requiredDataOk +
                    "\nencounterId=" + definition.EncounterId);
                return;
            }

            Debug.Log(
                "OperationEncounterLegacyScreenAdapterDebug OK" +
                "\nencounterId=" + definition.EncounterId +
                "\nparticipantId=" + screenModel.PatientDossier.PatientId +
                "\nprocedureId=" + screenModel.ProcedureDecision.SelectedProcedureId +
                "\nriskTier=" + screenModel.RiskAnalysis.RiskBand +
                "\npreviewChance=" + screenModel.RiskAnalysis.PreviewSuccessChance.ToString("0.000") +
                "\nexecuteChance=" + screenModel.RiskAnalysis.CommitSuccessChance.ToString("0.000") +
                "\ncreditsDelta=" + screenModel.OperationResult.CreditsDelta +
                "\nreputationDelta=" + screenModel.OperationResult.ReputationDelta +
                "\nlegacyShellCompatible=True" +
                "\ndataDrivenBridgeReady=True" +
                "\nuiBinding=operation_encounter_legacy_screen_adapter_ready");
        }
    }
}
#endif
