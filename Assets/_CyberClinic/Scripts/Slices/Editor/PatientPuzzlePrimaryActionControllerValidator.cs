#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionControllerValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action Controller Debug")]
        public static void RunDebug()
        {
            var controller = new PatientPuzzlePrimaryActionController();
            var initial = controller.CurrentState;
            var afterPreview = controller.Preview();
            var afterCommit = controller.Commit();
            var afterDisable = controller.Disable();
            var previewAfterDisable = controller.Preview();
            var afterReset = controller.Reset();

            var initialOk = IsState(initial, PreviewActionState.Available, CommitActionState.Available);
            var previewOk = IsState(afterPreview, PreviewActionState.Previewed, CommitActionState.Available);
            var commitOk = IsState(afterCommit, PreviewActionState.Previewed, CommitActionState.Committed);
            var disableOk = IsState(afterDisable, PreviewActionState.Disabled, CommitActionState.Disabled);
            var disabledPreservedOk = IsState(previewAfterDisable, PreviewActionState.Disabled, CommitActionState.Disabled);
            var resetOk = IsState(afterReset, PreviewActionState.Available, CommitActionState.Available);

            var customController = new PatientPuzzlePrimaryActionController(PatientPuzzlePrimaryActionStateResolver.Disabled());
            var customInitialOk = IsState(customController.CurrentState, PreviewActionState.Disabled, CommitActionState.Disabled);

            if (!initialOk || !previewOk || !commitOk || !disableOk || !disabledPreservedOk || !resetOk || !customInitialOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionControllerDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\ndisableOk=" + disableOk +
                    "\ndisabledPreservedOk=" + disabledPreservedOk +
                    "\nresetOk=" + resetOk +
                    "\ncustomInitialOk=" + customInitialOk +
                    "\ninitial=" + Format(initial) +
                    "\nafterPreview=" + Format(afterPreview) +
                    "\nafterCommit=" + Format(afterCommit) +
                    "\nafterDisable=" + Format(afterDisable) +
                    "\npreviewAfterDisable=" + Format(previewAfterDisable) +
                    "\nafterReset=" + Format(afterReset) +
                    "\ncustomInitial=" + Format(customController.CurrentState));
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionControllerDebug OK" +
                "\ninitialState=" + Format(initial) +
                "\nafterPreviewState=" + Format(afterPreview) +
                "\nafterCommitState=" + Format(afterCommit) +
                "\nafterDisableState=" + Format(afterDisable) +
                "\ndisabledPreserved=True" +
                "\nafterResetState=" + Format(afterReset) +
                "\ncustomInitialState=Disabled/Disabled" +
                "\nuiBinding=primary_action_controller_ready");
        }

        static bool IsState(PatientPuzzlePrimaryActionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.PreviewState == preview && state.CommitState == commit;
        }

        static string Format(PatientPuzzlePrimaryActionState state)
        {
            return state.PreviewState + "/" + state.CommitState;
        }
    }
}
#endif
