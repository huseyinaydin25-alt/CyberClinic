#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellPresenterValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Presenter Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var presentation = PatientPuzzleShellPresenter.Present(screenModel);

            var requiredOk = presentation.HasRequiredDebugData();
            var patientOk = presentation.PatientDossierBody.Contains("debug.patientId=test_street_netrunner") && presentation.PatientDossierBody.Contains("debug.patientSeed=82115621");
            var procedureOk = presentation.ProcedureDecisionBody.Contains("debug.selectedImplantId=test_implant_optic_tune") && presentation.ProcedureDecisionBody.Contains("debug.selectedProcedureId=test_proc_micro_install");
            var riskOk = presentation.RiskAnalysisBody.Contains("debug.riskBand=Uncertain") && presentation.RiskAnalysisBody.Contains("debug.outcomeType=StableSuccess");
            var resultOk = presentation.OperationResultBody.Contains("debug.creditsDelta=+90") && presentation.OperationResultBody.Contains("debug.reputationDelta=+5");
            var feedbackOk = presentation.ActionFeedbackBody.Contains("debug.visualCueId=test_cue_result_reveal") && presentation.ActionFeedbackBody.Contains("debug.audioCueId=test_audio_operation_success");

            if (!requiredOk || !patientOk || !procedureOk || !riskOk || !resultOk || !feedbackOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellPresenterDebug failed" +
                    "\nrequiredOk=" + requiredOk +
                    "\npatientOk=" + patientOk +
                    "\nprocedureOk=" + procedureOk +
                    "\nriskOk=" + riskOk +
                    "\nresultOk=" + resultOk +
                    "\nfeedbackOk=" + feedbackOk);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellPresenterDebug OK" +
                "\npatientPresentation=True" +
                "\nprocedurePresentation=True" +
                "\nriskPresentation=True" +
                "\nresultPresentation=True" +
                "\nfeedbackPresentation=True" +
                "\nuiBinding=shell_presenter_decoupled");
        }
    }
}
#endif
