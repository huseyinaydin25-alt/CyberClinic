#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionStateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Debug")]
        public static void RunDebug()
        {
            var defaultState = PatientPuzzlePrimaryActionState.DefaultAvailable;
            var previewStatesOk =
                PreviewActionState.Available != PreviewActionState.Previewed &&
                PreviewActionState.Available != PreviewActionState.Disabled &&
                PreviewActionState.Previewed != PreviewActionState.Disabled;
            var commitStatesOk =
                CommitActionState.Available != CommitActionState.Committed &&
                CommitActionState.Available != CommitActionState.Disabled &&
                CommitActionState.Committed != CommitActionState.Disabled;
            var defaultOk =
                defaultState.PreviewState == PreviewActionState.Available &&
                defaultState.CommitState == CommitActionState.Available;

            var previewedState = new PatientPuzzlePrimaryActionState(
                PreviewActionState.Previewed,
                CommitActionState.Available);
            var committedState = new PatientPuzzlePrimaryActionState(
                PreviewActionState.Previewed,
                CommitActionState.Committed);
            var disabledState = new PatientPuzzlePrimaryActionState(
                PreviewActionState.Disabled,
                CommitActionState.Disabled);

            var transitionsRepresentable =
                previewedState.PreviewState == PreviewActionState.Previewed &&
                previewedState.CommitState == CommitActionState.Available &&
                committedState.PreviewState == PreviewActionState.Previewed &&
                committedState.CommitState == CommitActionState.Committed &&
                disabledState.PreviewState == PreviewActionState.Disabled &&
                disabledState.CommitState == CommitActionState.Disabled;

            var presentation = PatientPuzzleShellPresenter.Present(PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel());
            var presenterBindingOk =
                presentation.PrimaryActionState.PreviewState == PreviewActionState.Available &&
                presentation.PrimaryActionState.CommitState == CommitActionState.Available &&
                presentation.PrimaryActionBody.Contains("debug.previewActionState=Available") &&
                presentation.PrimaryActionBody.Contains("debug.commitActionState=Available");

            if (!previewStatesOk || !commitStatesOk || !defaultOk || !transitionsRepresentable || !presenterBindingOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionStateDebug failed" +
                    "\npreviewStatesOk=" + previewStatesOk +
                    "\ncommitStatesOk=" + commitStatesOk +
                    "\ndefaultOk=" + defaultOk +
                    "\ntransitionsRepresentable=" + transitionsRepresentable +
                    "\npresenterBindingOk=" + presenterBindingOk +
                    "\npreviewState=" + presentation.PrimaryActionState.PreviewState +
                    "\ncommitState=" + presentation.PrimaryActionState.CommitState);
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionStateDebug OK" +
                "\npreviewStatesOk=True" +
                "\ncommitStatesOk=True" +
                "\ndefaultPreviewState=" + defaultState.PreviewState +
                "\ndefaultCommitState=" + defaultState.CommitState +
                "\npreviewedStateRepresentable=True" +
                "\ncommittedStateRepresentable=True" +
                "\ndisabledStateRepresentable=True" +
                "\npresenterBindingOk=True" +
                "\nuiBinding=primary_action_state_model_ready");
        }
    }
}
#endif
