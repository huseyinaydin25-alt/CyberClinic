namespace CyberClinic.Slices
{
    public enum PreviewActionState
    {
        Available,
        Previewed,
        Disabled
    }

    public enum CommitActionState
    {
        Available,
        Committed,
        Disabled
    }

    public readonly struct PatientPuzzlePrimaryActionState
    {
        public PatientPuzzlePrimaryActionState(
            PreviewActionState previewState,
            CommitActionState commitState)
        {
            PreviewState = previewState;
            CommitState = commitState;
        }

        public PreviewActionState PreviewState { get; }
        public CommitActionState CommitState { get; }

        public static PatientPuzzlePrimaryActionState DefaultAvailable =>
            new PatientPuzzlePrimaryActionState(
                PreviewActionState.Available,
                CommitActionState.Available);
    }
}
