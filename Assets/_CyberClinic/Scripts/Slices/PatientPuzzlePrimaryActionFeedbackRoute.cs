namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzlePrimaryActionFeedbackRoute
    {
        public PatientPuzzlePrimaryActionFeedbackRoute(
            string routeId,
            string visualCueId,
            string audioCueId,
            string readoutVisualTokenId,
            string summaryReadoutKey)
        {
            RouteId = routeId;
            VisualCueId = visualCueId;
            AudioCueId = audioCueId;
            ReadoutVisualTokenId = readoutVisualTokenId;
            SummaryReadoutKey = summaryReadoutKey;
        }

        public string RouteId { get; }
        public string VisualCueId { get; }
        public string AudioCueId { get; }
        public string ReadoutVisualTokenId { get; }
        public string SummaryReadoutKey { get; }
    }

    public static class PatientPuzzlePrimaryActionFeedbackRouter
    {
        public static PatientPuzzlePrimaryActionFeedbackRoute Route(PatientPuzzlePrimaryActionState state)
        {
            var readout = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(state);

            if (state.PreviewState == PreviewActionState.Disabled || state.CommitState == CommitActionState.Disabled)
            {
                return Build(
                    "primary_action.feedback.disabled",
                    "test_cue_primary_action_disabled",
                    "test_audio_primary_action_disabled",
                    readout);
            }

            if (state.PreviewState == PreviewActionState.Previewed && state.CommitState == CommitActionState.Committed)
            {
                return Build(
                    "primary_action.feedback.committed",
                    "test_cue_primary_action_committed",
                    "test_audio_operation_success",
                    readout);
            }

            if (state.PreviewState == PreviewActionState.Previewed && state.CommitState == CommitActionState.Available)
            {
                return Build(
                    "primary_action.feedback.previewed",
                    "test_cue_primary_action_previewed",
                    "test_audio_primary_action_previewed",
                    readout);
            }

            return Build(
                "primary_action.feedback.ready",
                "test_cue_primary_action_ready",
                "test_audio_primary_action_ready",
                readout);
        }

        static PatientPuzzlePrimaryActionFeedbackRoute Build(
            string routeId,
            string visualCueId,
            string audioCueId,
            PatientPuzzlePrimaryActionStateReadout readout)
        {
            return new PatientPuzzlePrimaryActionFeedbackRoute(
                routeId,
                visualCueId,
                audioCueId,
                readout.VisualTokenId,
                readout.SummaryReadoutKey);
        }
    }
}
