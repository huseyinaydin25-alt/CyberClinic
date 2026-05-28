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

    public static class PatientPuzzlePrimaryActionStateResolver
    {
        public static PatientPuzzlePrimaryActionState Initial()
        {
            return PatientPuzzlePrimaryActionState.DefaultAvailable;
        }

        public static PatientPuzzlePrimaryActionState AfterPreview(PatientPuzzlePrimaryActionState current)
        {
            if (current.PreviewState == PreviewActionState.Disabled || current.CommitState == CommitActionState.Disabled)
            {
                return Disabled();
            }

            return new PatientPuzzlePrimaryActionState(
                PreviewActionState.Previewed,
                CommitActionState.Available);
        }

        public static PatientPuzzlePrimaryActionState AfterCommit(PatientPuzzlePrimaryActionState current)
        {
            if (current.PreviewState == PreviewActionState.Disabled || current.CommitState == CommitActionState.Disabled)
            {
                return Disabled();
            }

            return new PatientPuzzlePrimaryActionState(
                PreviewActionState.Previewed,
                CommitActionState.Committed);
        }

        public static PatientPuzzlePrimaryActionState Disabled()
        {
            return new PatientPuzzlePrimaryActionState(
                PreviewActionState.Disabled,
                CommitActionState.Disabled);
        }
    }
}
