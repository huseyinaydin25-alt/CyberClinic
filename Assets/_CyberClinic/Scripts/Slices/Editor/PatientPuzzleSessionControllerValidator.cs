#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleSessionControllerValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Session Controller Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new PatientPuzzleSessionController(screenModel);

            var initial = controller.CurrentState;
            var afterPreview = controller.Preview();
            var afterCommit = controller.Commit();
            var previewAfterCommit = controller.Preview();
            var commitAfterCommit = controller.Commit();
            var afterReset = controller.Reset();
            var afterDisable = controller.Disable();
            var previewAfterDisable = controller.Preview();
            var afterSecondReset = controller.Reset();

            var initialOk =
                IsState(initial, PreviewActionState.Available, CommitActionState.Available) &&
                initial.LastInteractionId == "patient_puzzle.session.initial" &&
                initial.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !initial.HasPreviewed &&
                !initial.HasCommitted &&
                !initial.IsLocked;

            var previewOk =
                IsState(afterPreview, PreviewActionState.Previewed, CommitActionState.Available) &&
                afterPreview.LastInteractionId == "primary_action.preview" &&
                afterPreview.LastFeedbackRoute.RouteId == "primary_action.feedback.previewed" &&
                afterPreview.HasPreviewed &&
                !afterPreview.HasCommitted &&
                !afterPreview.IsLocked;

            var commitOk =
                IsState(afterCommit, PreviewActionState.Previewed, CommitActionState.Committed) &&
                afterCommit.LastInteractionId == "primary_action.commit" &&
                afterCommit.LastFeedbackRoute.RouteId == "primary_action.feedback.committed" &&
                afterCommit.HasPreviewed &&
                afterCommit.HasCommitted &&
                afterCommit.IsLocked;

            var lockedPreservedOk =
                SameSessionState(afterCommit, previewAfterCommit) &&
                SameSessionState(afterCommit, commitAfterCommit);

            var resetOk =
                IsState(afterReset, PreviewActionState.Available, CommitActionState.Available) &&
                afterReset.LastInteractionId == "patient_puzzle.session.initial" &&
                afterReset.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !afterReset.HasPreviewed &&
                !afterReset.HasCommitted &&
                !afterReset.IsLocked;

            var disableOk =
                IsState(afterDisable, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                afterDisable.LastInteractionId == "primary_action.disable" &&
                afterDisable.LastFeedbackRoute.RouteId == "primary_action.feedback.disabled" &&
                !afterDisable.HasPreviewed &&
                !afterDisable.HasCommitted &&
                afterDisable.IsLocked;

            var disabledPreservedOk = SameSessionState(afterDisable, previewAfterDisable);

            var secondResetOk =
                IsState(afterSecondReset, PreviewActionState.Available, CommitActionState.Available) &&
                afterSecondReset.LastInteractionId == "patient_puzzle.session.initial" &&
                !afterSecondReset.IsLocked;

            if (!initialOk || !previewOk || !commitOk || !lockedPreservedOk || !resetOk || !disableOk || !disabledPreservedOk || !secondResetOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleSessionControllerDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\nlockedPreservedOk=" + lockedPreservedOk +
                    "\nresetOk=" + resetOk +
                    "\ndisableOk=" + disableOk +
                    "\ndisabledPreservedOk=" + disabledPreservedOk +
                    "\nsecondResetOk=" + secondResetOk +
                    "\ninitial=" + Format(initial) +
                    "\nafterPreview=" + Format(afterPreview) +
                    "\nafterCommit=" + Format(afterCommit) +
                    "\npreviewAfterCommit=" + Format(previewAfterCommit) +
                    "\ncommitAfterCommit=" + Format(commitAfterCommit) +
                    "\nafterReset=" + Format(afterReset) +
                    "\nafterDisable=" + Format(afterDisable) +
                    "\npreviewAfterDisable=" + Format(previewAfterDisable) +
                    "\nafterSecondReset=" + Format(afterSecondReset));
                return;
            }

            Debug.Log(
                "PatientPuzzleSessionControllerDebug OK" +
                "\ninitialState=Available/Available" +
                "\nafterPreviewState=Previewed/Available" +
                "\nafterCommitState=Previewed/Committed" +
                "\nafterCommitLocked=True" +
                "\nlockedPreserved=True" +
                "\nafterResetState=Available/Available" +
                "\nafterDisableState=Disabled/Disabled" +
                "\ndisabledPreserved=True" +
                "\nafterSecondResetState=Available/Available" +
                "\nuiBinding=patient_puzzle_session_controller_ready");
        }

        static bool IsState(PatientPuzzleSessionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.PrimaryActionState.PreviewState == preview && state.PrimaryActionState.CommitState == commit;
        }

        static bool SameSessionState(PatientPuzzleSessionState left, PatientPuzzleSessionState right)
        {
            return
                left.PrimaryActionState.PreviewState == right.PrimaryActionState.PreviewState &&
                left.PrimaryActionState.CommitState == right.PrimaryActionState.CommitState &&
                left.LastInteractionId == right.LastInteractionId &&
                left.LastFeedbackRoute.RouteId == right.LastFeedbackRoute.RouteId &&
                left.HasPreviewed == right.HasPreviewed &&
                left.HasCommitted == right.HasCommitted &&
                left.IsLocked == right.IsLocked;
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
