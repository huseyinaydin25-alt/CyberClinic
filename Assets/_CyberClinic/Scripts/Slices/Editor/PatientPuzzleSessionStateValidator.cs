#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleSessionStateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Session State Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var initial = PatientPuzzleSessionState.CreateInitial(screenModel);

            var previewState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial.PrimaryActionState);
            var afterPreview = initial.WithInteraction("primary_action.preview", previewState);

            var commitState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(afterPreview.PrimaryActionState);
            var afterCommit = afterPreview.WithInteraction("primary_action.commit", commitState);

            var afterDisable = afterPreview.WithLockedDisabled("primary_action.disable");
            var afterReset = afterCommit.Reset();

            var initialOk =
                initial.ScreenModel.PatientDossier.PatientId == screenModel.PatientDossier.PatientId &&
                IsState(initial.PrimaryActionState, PreviewActionState.Available, CommitActionState.Available) &&
                initial.LastInteractionId == "patient_puzzle.session.initial" &&
                initial.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !initial.HasPreviewed &&
                !initial.HasCommitted &&
                !initial.IsLocked;

            var previewOk =
                IsState(afterPreview.PrimaryActionState, PreviewActionState.Previewed, CommitActionState.Available) &&
                afterPreview.LastInteractionId == "primary_action.preview" &&
                afterPreview.LastFeedbackRoute.RouteId == "primary_action.feedback.previewed" &&
                afterPreview.HasPreviewed &&
                !afterPreview.HasCommitted &&
                !afterPreview.IsLocked;

            var commitOk =
                IsState(afterCommit.PrimaryActionState, PreviewActionState.Previewed, CommitActionState.Committed) &&
                afterCommit.LastInteractionId == "primary_action.commit" &&
                afterCommit.LastFeedbackRoute.RouteId == "primary_action.feedback.committed" &&
                afterCommit.HasPreviewed &&
                afterCommit.HasCommitted &&
                afterCommit.IsLocked;

            var disableOk =
                IsState(afterDisable.PrimaryActionState, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                afterDisable.LastInteractionId == "primary_action.disable" &&
                afterDisable.LastFeedbackRoute.RouteId == "primary_action.feedback.disabled" &&
                afterDisable.HasPreviewed &&
                !afterDisable.HasCommitted &&
                afterDisable.IsLocked;

            var resetOk =
                IsState(afterReset.PrimaryActionState, PreviewActionState.Available, CommitActionState.Available) &&
                afterReset.LastInteractionId == "patient_puzzle.session.initial" &&
                afterReset.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !afterReset.HasPreviewed &&
                !afterReset.HasCommitted &&
                !afterReset.IsLocked;

            if (!initialOk || !previewOk || !commitOk || !disableOk || !resetOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleSessionStateDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\ndisableOk=" + disableOk +
                    "\nresetOk=" + resetOk +
                    "\ninitial=" + Format(initial) +
                    "\nafterPreview=" + Format(afterPreview) +
                    "\nafterCommit=" + Format(afterCommit) +
                    "\nafterDisable=" + Format(afterDisable) +
                    "\nafterReset=" + Format(afterReset));
                return;
            }

            Debug.Log(
                "PatientPuzzleSessionStateDebug OK" +
                "\ninitialState=Available/Available" +
                "\ninitialRoute=primary_action.feedback.ready" +
                "\nafterPreviewState=Previewed/Available" +
                "\nafterPreviewRoute=primary_action.feedback.previewed" +
                "\nafterCommitState=Previewed/Committed" +
                "\nafterCommitRoute=primary_action.feedback.committed" +
                "\nafterCommitLocked=True" +
                "\nafterDisableState=Disabled/Disabled" +
                "\nafterDisableRoute=primary_action.feedback.disabled" +
                "\nafterResetState=Available/Available" +
                "\nuiBinding=patient_puzzle_session_state_ready");
        }

        static bool IsState(PatientPuzzlePrimaryActionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.PreviewState == preview && state.CommitState == commit;
        }

        static string Format(PatientPuzzleSessionState state)
        {
            return state.LastInteractionId + "/" +
                   state.PrimaryActionState.PreviewState + "/" +
                   state.PrimaryActionState.CommitState + "/" +
                   state.LastFeedbackRoute.RouteId +
                   "/previewed=" + state.HasPreviewed +
                   "/committed=" + state.HasCommitted +
                   "/locked=" + state.IsLocked;
        }
    }
}
#endif
