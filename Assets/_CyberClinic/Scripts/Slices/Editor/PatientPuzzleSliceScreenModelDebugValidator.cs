#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleSliceScreenModelDebugValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Slice ScreenModel Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();

            var requiredOk = screenModel.HasRequiredDebugData();
            var patientOk = screenModel.PatientDossier.PatientId == "test_street_netrunner" && screenModel.PatientDossier.PatientSeed == 82115621;
            var procedureOk = screenModel.ProcedureDecision.SelectedImplantId == "test_implant_optic_tune" && screenModel.ProcedureDecision.SelectedProcedureId == "test_proc_micro_install";
            var riskOk = screenModel.RiskAnalysis.RiskBand == "Uncertain" && screenModel.RiskAnalysis.OutcomeType == "StableSuccess";
            var resultOk = screenModel.OperationResult.CreditsDelta == 90 && screenModel.OperationResult.ReputationDelta == 5;
            var feedbackOk = screenModel.ActionFeedback.VisualCueId == "test_cue_result_reveal" && screenModel.ActionFeedback.AudioCueId == "test_audio_operation_success";

            if (!requiredOk || !patientOk || !procedureOk || !riskOk || !resultOk || !feedbackOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleSliceScreenModelDebug failed" +
                    "\nrequiredOk=" + requiredOk +
                    "\npatientOk=" + patientOk +
                    "\nprocedureOk=" + procedureOk +
                    "\nriskOk=" + riskOk +
                    "\nresultOk=" + resultOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\npatientId=" + screenModel.PatientDossier.PatientId +
                    "\nselectedImplantId=" + screenModel.ProcedureDecision.SelectedImplantId +
                    "\nselectedProcedureId=" + screenModel.ProcedureDecision.SelectedProcedureId +
                    "\nriskBand=" + screenModel.RiskAnalysis.RiskBand +
                    "\noutcomeType=" + screenModel.RiskAnalysis.OutcomeType +
                    "\ncreditsDelta=" + screenModel.OperationResult.CreditsDelta +
                    "\nreputationDelta=" + screenModel.OperationResult.ReputationDelta +
                    "\nvisualCueId=" + screenModel.ActionFeedback.VisualCueId +
                    "\naudioCueId=" + screenModel.ActionFeedback.AudioCueId);
                return;
            }

            Debug.Log(
                "PatientPuzzleSliceScreenModelDebug OK" +
                "\npatientSection.patientId=" + screenModel.PatientDossier.PatientId +
                "\npatientSection.patientSeed=" + screenModel.PatientDossier.PatientSeed +
                "\nprocedureSection.selectedImplantId=" + screenModel.ProcedureDecision.SelectedImplantId +
                "\nprocedureSection.selectedProcedureId=" + screenModel.ProcedureDecision.SelectedProcedureId +
                "\nriskSection.previewSuccessChance=" + screenModel.RiskAnalysis.PreviewSuccessChance.ToString("F3") +
                "\nriskSection.commitSuccessChance=" + screenModel.RiskAnalysis.CommitSuccessChance.ToString("F3") +
                "\nriskSection.riskBand=" + screenModel.RiskAnalysis.RiskBand +
                "\nriskSection.outcomeType=" + screenModel.RiskAnalysis.OutcomeType +
                "\nresultSection.creditsDelta=" + screenModel.OperationResult.CreditsDelta +
                "\nresultSection.reputationDelta=" + screenModel.OperationResult.ReputationDelta +
                "\nfeedbackSection.visualCueId=" + screenModel.ActionFeedback.VisualCueId +
                "\nfeedbackSection.audioCueId=" + screenModel.ActionFeedback.AudioCueId +
                "\nuiBinding=sectioned_screen_model");
        }
    }
}
#endif
