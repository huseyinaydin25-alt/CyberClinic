namespace CyberClinic.Slices
{
    public sealed class PatientPuzzleSessionController
    {
        public PatientPuzzleSessionController(PatientPuzzleSliceScreenModel screenModel)
            : this(PatientPuzzleSessionState.CreateInitial(screenModel))
        {
        }

        public PatientPuzzleSessionController(PatientPuzzleSessionState initialState)
        {
            CurrentState = initialState;
        }

        public PatientPuzzleSessionState CurrentState { get; private set; }

        public PatientPuzzleSessionState Preview()
        {
            if (CurrentState.IsLocked)
            {
                return CurrentState;
            }

            var nextState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(CurrentState.PrimaryActionState);
            CurrentState = CurrentState.WithInteraction("primary_action.preview", nextState);
            return CurrentState;
        }

        public PatientPuzzleSessionState Commit()
        {
            if (CurrentState.IsLocked)
            {
                return CurrentState;
            }

            var nextState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(CurrentState.PrimaryActionState);
            CurrentState = CurrentState.WithInteraction("primary_action.commit", nextState);
            return CurrentState;
        }

        public PatientPuzzleSessionState Disable()
        {
            if (CurrentState.IsLocked &&
                CurrentState.PrimaryActionState.PreviewState == PreviewActionState.Disabled &&
                CurrentState.PrimaryActionState.CommitState == CommitActionState.Disabled)
            {
                return CurrentState;
            }

            CurrentState = CurrentState.WithLockedDisabled("primary_action.disable");
            return CurrentState;
        }

        public PatientPuzzleSessionState Reset()
        {
            CurrentState = CurrentState.Reset();
            return CurrentState;
        }
    }
}
