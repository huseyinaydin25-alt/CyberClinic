#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionFeedbackRouterValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action Feedback Router Debug")]
        public static void RunDebug()
        {
            var ready = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewed = PatientPuzzlePrimaryActionFeedbackRouter.Route(previewedState);
            var committedState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewedState);
            var committed = PatientPuzzlePrimaryActionFeedbackRouter.Route(committedState);
            var disabled = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.Disabled());

            var readyOk =
                ready.RouteId == "primary_action.feedback.ready" &&
                ready.VisualCueId == "test_cue_primary_action_ready" &&
                ready.AudioCueId == "test_audio_primary_action_ready" &&
                ready.ReadoutVisualTokenId == "primary_action.visual.ready" &&
                ready.SummaryReadoutKey == "ui.primary_action.summary.ready";
            var previewedOk =
                previewed.RouteId == "primary_action.feedback.previewed" &&
                previewed.VisualCueId == "test_cue_primary_action_previewed" &&
                previewed.AudioCueId == "test_audio_primary_action_previewed" &&
                previewed.ReadoutVisualTokenId == "primary_action.visual.previewed" &&
                previewed.SummaryReadoutKey == "ui.primary_action.summary.previewed";
            var committedOk =
                committed.RouteId == "primary_action.feedback.committed" &&
                committed.VisualCueId == "test_cue_primary_action_committed" &&
                committed.AudioCueId == "test_audio_operation_success" &&
                committed.ReadoutVisualTokenId == "primary_action.visual.committed" &&
                committed.SummaryReadoutKey == "ui.primary_action.summary.committed";
            var disabledOk =
                disabled.RouteId == "primary_action.feedback.disabled" &&
                disabled.VisualCueId == "test_cue_primary_action_disabled" &&
                disabled.AudioCueId == "test_audio_primary_action_disabled" &&
                disabled.ReadoutVisualTokenId == "primary_action.visual.disabled" &&
                disabled.SummaryReadoutKey == "ui.primary_action.summary.disabled";

            if (!readyOk || !previewedOk || !committedOk || !disabledOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionFeedbackRouterDebug failed" +
                    "\nreadyOk=" + readyOk +
                    "\npreviewedOk=" + previewedOk +
                    "\ncommittedOk=" + committedOk +
                    "\ndisabledOk=" + disabledOk +
                    "\nready=" + Format(ready) +
                    "\npreviewed=" + Format(previewed) +
                    "\ncommitted=" + Format(committed) +
                    "\ndisabled=" + Format(disabled));
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionFeedbackRouterDebug OK" +
                "\nreadyRoute=" + ready.RouteId +
                "\npreviewedRoute=" + previewed.RouteId +
                "\ncommittedRoute=" + committed.RouteId +
                "\ndisabledRoute=" + disabled.RouteId +
                "\nreadyVisualCueId=" + ready.VisualCueId +
                "\npreviewedVisualCueId=" + previewed.VisualCueId +
                "\ncommittedVisualCueId=" + committed.VisualCueId +
                "\ndisabledVisualCueId=" + disabled.VisualCueId +
                "\nuiBinding=primary_action_feedback_router_ready");
        }

        static string Format(PatientPuzzlePrimaryActionFeedbackRoute route)
        {
            return route.RouteId + "/" +
                   route.VisualCueId + "/" +
                   route.AudioCueId + "/" +
                   route.ReadoutVisualTokenId + "/" +
                   route.SummaryReadoutKey;
        }
    }
}
#endif
