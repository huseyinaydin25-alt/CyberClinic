#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionStateResolverValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Resolver Debug")]
        public static void RunDebug()
        {
            var initial = PatientPuzzlePrimaryActionStateResolver.Initial();
            var afterPreview = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial);
            var afterCommit = PatientPuzzlePrimaryActionStateResolver.AfterCommit(afterPreview);
            var disabled = PatientPuzzlePrimaryActionStateResolver.Disabled();
            var previewFromDisabled = PatientPuzzlePrimaryActionStateResolver.AfterPreview(disabled);
            var commitFromDisabled = PatientPuzzlePrimaryActionStateResolver.AfterCommit(disabled);

            var initialOk =
                initial.PreviewState == PreviewActionState.Available &&
                initial.CommitState == CommitActionState.Available;
            var afterPreviewOk =
                afterPreview.PreviewState == PreviewActionState.Previewed &&
                afterPreview.CommitState == CommitActionState.Available;
            var afterCommitOk =
                afterCommit.PreviewState == PreviewActionState.Previewed &&
                afterCommit.CommitState == CommitActionState.Committed;
            var disabledOk =
                disabled.PreviewState == PreviewActionState.Disabled &&
                disabled.CommitState == CommitActionState.Disabled;
            var disabledPreservedOk =
                previewFromDisabled.PreviewState == PreviewActionState.Disabled &&
                previewFromDisabled.CommitState == CommitActionState.Disabled &&
                commitFromDisabled.PreviewState == PreviewActionState.Disabled &&
                commitFromDisabled.CommitState == CommitActionState.Disabled;

            if (!initialOk || !afterPreviewOk || !afterCommitOk || !disabledOk || !disabledPreservedOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionStateResolverDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\nafterPreviewOk=" + afterPreviewOk +
                    "\nafterCommitOk=" + afterCommitOk +
                    "\ndisabledOk=" + disabledOk +
                    "\ndisabledPreservedOk=" + disabledPreservedOk +
                    "\ninitial=" + Format(initial) +
                    "\nafterPreview=" + Format(afterPreview) +
                    "\nafterCommit=" + Format(afterCommit) +
                    "\ndisabled=" + Format(disabled) +
                    "\npreviewFromDisabled=" + Format(previewFromDisabled) +
                    "\ncommitFromDisabled=" + Format(commitFromDisabled));
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionStateResolverDebug OK" +
                "\ninitialState=" + Format(initial) +
                "\nafterPreviewState=" + Format(afterPreview) +
                "\nafterCommitState=" + Format(afterCommit) +
                "\ndisabledState=" + Format(disabled) +
                "\ndisabledPreserved=True" +
                "\nuiBinding=primary_action_state_resolver_ready");
        }

        static string Format(PatientPuzzlePrimaryActionState state)
        {
            return state.PreviewState + "/" + state.CommitState;
        }
    }
}
#endif
