#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleSliceViewModelDebugValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Slice ViewModel Debug")]
        public static void RunDebug()
        {
            var viewModel = PatientPuzzleSliceViewModelBuilder.BuildDebugViewModel();

            var requiredOk = viewModel.HasRequiredDebugData();
            var deltasOk = viewModel.CreditsDelta == 90 && viewModel.ReputationDelta == 5;
            var chanceOk = viewModel.PreviewSuccessChance > 0f && viewModel.CommitSuccessChance > 0f;
            var knownIdsOk =
                viewModel.PatientId == "test_street_netrunner" &&
                viewModel.SelectedImplantId == "test_implant_optic_tune" &&
                viewModel.SelectedProcedureId == "test_proc_micro_install";

            if (!requiredOk || !deltasOk || !chanceOk || !knownIdsOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleSliceViewModelDebug failed" +
                    "\nrequiredOk=" + requiredOk +
                    "\ndeltasOk=" + deltasOk +
                    "\nchanceOk=" + chanceOk +
                    "\nknownIdsOk=" + knownIdsOk +
                    "\npatientId=" + viewModel.PatientId +
                    "\nselectedImplantId=" + viewModel.SelectedImplantId +
                    "\nselectedProcedureId=" + viewModel.SelectedProcedureId +
                    "\ncreditsDelta=" + viewModel.CreditsDelta +
                    "\nreputationDelta=" + viewModel.ReputationDelta);
                return;
            }

            Debug.Log(
                "PatientPuzzleSliceViewModelDebug OK" +
                "\npatientId=" + viewModel.PatientId +
                "\npatientSeed=" + viewModel.PatientSeed +
                "\nselectedImplantId=" + viewModel.SelectedImplantId +
                "\nselectedProcedureId=" + viewModel.SelectedProcedureId +
                "\npreviewSuccessChance=" + viewModel.PreviewSuccessChance.ToString("F3") +
                "\ncommitSuccessChance=" + viewModel.CommitSuccessChance.ToString("F3") +
                "\nriskBand=" + viewModel.RiskBand +
                "\noutcomeType=" + viewModel.OutcomeType +
                "\ncreditsDelta=" + viewModel.CreditsDelta +
                "\nreputationDelta=" + viewModel.ReputationDelta +
                "\nvisualCueId=" + viewModel.VisualCueId +
                "\naudioCueId=" + viewModel.AudioCueId +
                "\nsaveSummary=" + viewModel.SaveSummary +
                "\nuiBinding=decoupled_view_model");
        }
    }
}
#endif
