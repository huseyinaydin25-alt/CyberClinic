#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleSliceDataConsistencyValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Slice Data Consistency")]
        public static void RunConsistency()
        {
            var viewModel = PatientPuzzleSliceViewModelBuilder.BuildDebugViewModel();
            var screenModel = PatientPuzzleSliceScreenModelBuilder.FromViewModel(viewModel);

            var requiredOk = viewModel.HasRequiredDebugData() && screenModel.HasRequiredDebugData();
            var patientOk =
                viewModel.PatientId == screenModel.PatientDossier.PatientId &&
                viewModel.PatientSeed == screenModel.PatientDossier.PatientSeed;
            var procedureOk =
                viewModel.SelectedImplantId == screenModel.ProcedureDecision.SelectedImplantId &&
                viewModel.SelectedProcedureId == screenModel.ProcedureDecision.SelectedProcedureId;
            var riskOk =
                Approximately(viewModel.PreviewSuccessChance, screenModel.RiskAnalysis.PreviewSuccessChance) &&
                Approximately(viewModel.CommitSuccessChance, screenModel.RiskAnalysis.CommitSuccessChance) &&
                viewModel.RiskBand == screenModel.RiskAnalysis.RiskBand &&
                viewModel.OutcomeType == screenModel.RiskAnalysis.OutcomeType;
            var resultOk =
                viewModel.StartingCredits == screenModel.OperationResult.StartingCredits &&
                viewModel.EndingCredits == screenModel.OperationResult.EndingCredits &&
                viewModel.StartingReputation == screenModel.OperationResult.StartingReputation &&
                viewModel.EndingReputation == screenModel.OperationResult.EndingReputation &&
                viewModel.CreditsDelta == screenModel.OperationResult.CreditsDelta &&
                viewModel.ReputationDelta == screenModel.OperationResult.ReputationDelta &&
                viewModel.OutcomeType == screenModel.OperationResult.OutcomeType &&
                viewModel.SaveSummary == screenModel.OperationResult.SaveSummary;
            var feedbackOk =
                viewModel.VisualCueId == screenModel.ActionFeedback.VisualCueId &&
                viewModel.AudioCueId == screenModel.ActionFeedback.AudioCueId;
            var deterministicOk =
                viewModel.PatientId == "test_street_netrunner" &&
                viewModel.PatientSeed == 82115621 &&
                viewModel.SelectedImplantId == "test_implant_optic_tune" &&
                viewModel.SelectedProcedureId == "test_proc_micro_install" &&
                viewModel.RiskBand == "Uncertain" &&
                viewModel.OutcomeType == "StableSuccess" &&
                viewModel.CreditsDelta == 90 &&
                viewModel.ReputationDelta == 5 &&
                viewModel.VisualCueId == "test_cue_result_reveal" &&
                viewModel.AudioCueId == "test_audio_operation_success";

            if (!requiredOk || !patientOk || !procedureOk || !riskOk || !resultOk || !feedbackOk || !deterministicOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleSliceDataConsistency failed" +
                    "\nrequiredOk=" + requiredOk +
                    "\npatientOk=" + patientOk +
                    "\nprocedureOk=" + procedureOk +
                    "\nriskOk=" + riskOk +
                    "\nresultOk=" + resultOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\ndeterministicOk=" + deterministicOk +
                    "\nviewModel.patientId=" + viewModel.PatientId +
                    "\nscreenModel.patientId=" + screenModel.PatientDossier.PatientId +
                    "\nviewModel.creditsDelta=" + viewModel.CreditsDelta +
                    "\nscreenModel.creditsDelta=" + screenModel.OperationResult.CreditsDelta +
                    "\nviewModel.reputationDelta=" + viewModel.ReputationDelta +
                    "\nscreenModel.reputationDelta=" + screenModel.OperationResult.ReputationDelta +
                    "\nviewModel.riskBand=" + viewModel.RiskBand +
                    "\nscreenModel.riskBand=" + screenModel.RiskAnalysis.RiskBand +
                    "\nviewModel.outcomeType=" + viewModel.OutcomeType +
                    "\nscreenModel.outcomeType=" + screenModel.RiskAnalysis.OutcomeType);
                return;
            }

            Debug.Log(
                "PatientPuzzleSliceDataConsistency OK" +
                "\nviewModel=valid" +
                "\nscreenModel=valid" +
                "\npatientMatch=True" +
                "\nprocedureMatch=True" +
                "\nriskMatch=True" +
                "\nresultMatch=True" +
                "\nfeedbackMatch=True" +
                "\ndeterministicMatch=True" +
                "\npatientId=" + viewModel.PatientId +
                "\nselectedImplantId=" + viewModel.SelectedImplantId +
                "\nselectedProcedureId=" + viewModel.SelectedProcedureId +
                "\nriskBand=" + viewModel.RiskBand +
                "\noutcomeType=" + viewModel.OutcomeType +
                "\ncreditsDelta=" + viewModel.CreditsDelta +
                "\nreputationDelta=" + viewModel.ReputationDelta +
                "\nvisualCueId=" + viewModel.VisualCueId +
                "\naudioCueId=" + viewModel.AudioCueId +
                "\nuiBinding=viewmodel_screenmodel_consistent");
        }

        static bool Approximately(float a, float b)
        {
            return Mathf.Abs(a - b) < 0.0001f;
        }
    }
}
#endif
