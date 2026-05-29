namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzlePrimaryActionStateReadout
    {
        public PatientPuzzlePrimaryActionStateReadout(
            string previewReadoutKey,
            string commitReadoutKey,
            string summaryReadoutKey,
            string visualTokenId,
            bool isInteractive)
        {
            PreviewReadoutKey = previewReadoutKey;
            CommitReadoutKey = commitReadoutKey;
            SummaryReadoutKey = summaryReadoutKey;
            VisualTokenId = visualTokenId;
            IsInteractive = isInteractive;
        }

        public string PreviewReadoutKey { get; }
        public string CommitReadoutKey { get; }
        public string SummaryReadoutKey { get; }
        public string VisualTokenId { get; }
        public bool IsInteractive { get; }
    }

    public static class PatientPuzzlePrimaryActionStateReadoutPresenter
    {
        public static PatientPuzzlePrimaryActionStateReadout Present(PatientPuzzlePrimaryActionState state)
        {
            if (state.PreviewState == PreviewActionState.Disabled || state.CommitState == CommitActionState.Disabled)
            {
                return new PatientPuzzlePrimaryActionStateReadout(
                    "ui.primary_action.preview.disabled",
                    "ui.primary_action.commit.disabled",
                    "ui.primary_action.summary.disabled",
                    "primary_action.visual.disabled",
                    false);
            }

            if (state.PreviewState == PreviewActionState.Previewed && state.CommitState == CommitActionState.Committed)
            {
                return new PatientPuzzlePrimaryActionStateReadout(
                    "ui.primary_action.preview.previewed",
                    "ui.primary_action.commit.committed",
                    "ui.primary_action.summary.committed",
                    "primary_action.visual.committed",
                    false);
            }

            if (state.PreviewState == PreviewActionState.Previewed && state.CommitState == CommitActionState.Available)
            {
                return new PatientPuzzlePrimaryActionStateReadout(
                    "ui.primary_action.preview.previewed",
                    "ui.primary_action.commit.available",
                    "ui.primary_action.summary.previewed",
                    "primary_action.visual.previewed",
                    true);
            }

            return new PatientPuzzlePrimaryActionStateReadout(
                "ui.primary_action.preview.available",
                "ui.primary_action.commit.available",
                "ui.primary_action.summary.ready",
                "primary_action.visual.ready",
                true);
        }
    }
}
