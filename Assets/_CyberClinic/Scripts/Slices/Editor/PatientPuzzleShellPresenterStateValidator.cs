#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellPresenterStateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Presenter State Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var initialState = PatientPuzzlePrimaryActionStateResolver.Initial();
            var previewedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initialState);
            var committedState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewedState);
            var disabledState = PatientPuzzlePrimaryActionStateResolver.Disabled();

            var defaultPresentation = PatientPuzzleShellPresenter.Present(screenModel);
            var initialPresentation = PatientPuzzleShellPresenter.Present(screenModel, initialState);
            var previewedPresentation = PatientPuzzleShellPresenter.Present(screenModel, previewedState);
            var committedPresentation = PatientPuzzleShellPresenter.Present(screenModel, committedState);
            var disabledPresentation = PatientPuzzleShellPresenter.Present(screenModel, disabledState);

            var defaultOk =
                defaultPresentation.HasPrimaryActionState(initialState) &&
                defaultPresentation.PrimaryActionBody.Contains("debug.previewActionState=Available") &&
                defaultPresentation.PrimaryActionBody.Contains("debug.commitActionState=Available");
            var initialOk =
                initialPresentation.HasPrimaryActionState(initialState) &&
                initialPresentation.PrimaryActionBody.Contains("debug.previewActionState=Available") &&
                initialPresentation.PrimaryActionBody.Contains("debug.commitActionState=Available");
            var previewedOk =
                previewedPresentation.HasPrimaryActionState(previewedState) &&
                previewedPresentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                previewedPresentation.PrimaryActionBody.Contains("debug.commitActionState=Available");
            var committedOk =
                committedPresentation.HasPrimaryActionState(committedState) &&
                committedPresentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                committedPresentation.PrimaryActionBody.Contains("debug.commitActionState=Committed");
            var disabledOk =
                disabledPresentation.HasPrimaryActionState(disabledState) &&
                disabledPresentation.PrimaryActionBody.Contains("debug.previewActionState=Disabled") &&
                disabledPresentation.PrimaryActionBody.Contains("debug.commitActionState=Disabled");

            if (!defaultOk || !initialOk || !previewedOk || !committedOk || !disabledOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellPresenterStateDebug failed" +
                    "\ndefaultOk=" + defaultOk +
                    "\ninitialOk=" + initialOk +
                    "\npreviewedOk=" + previewedOk +
                    "\ncommittedOk=" + committedOk +
                    "\ndisabledOk=" + disabledOk +
                    "\ndefaultBody=" + defaultPresentation.PrimaryActionBody +
                    "\npreviewedBody=" + previewedPresentation.PrimaryActionBody +
                    "\ncommittedBody=" + committedPresentation.PrimaryActionBody +
                    "\ndisabledBody=" + disabledPresentation.PrimaryActionBody);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellPresenterStateDebug OK" +
                "\ndefaultState=Available/Available" +
                "\ninitialState=Available/Available" +
                "\npreviewedState=Previewed/Available" +
                "\ncommittedState=Previewed/Committed" +
                "\ndisabledState=Disabled/Disabled" +
                "\nuiBinding=shell_presenter_state_aware_ready");
        }
    }
}
#endif
