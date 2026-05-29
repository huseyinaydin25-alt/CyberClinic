namespace CyberClinic.Slices
{
    public sealed class PatientPuzzlePrimaryActionController
    {
        public PatientPuzzlePrimaryActionController()
            : this(PatientPuzzlePrimaryActionStateResolver.Initial())
        {
        }

        public PatientPuzzlePrimaryActionController(PatientPuzzlePrimaryActionState initialState)
        {
            CurrentState = initialState;
        }

        public PatientPuzzlePrimaryActionState CurrentState { get; private set; }

        public PatientPuzzlePrimaryActionState Preview()
        {
            CurrentState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(CurrentState);
            return CurrentState;
        }

        public PatientPuzzlePrimaryActionState Commit()
        {
            CurrentState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(CurrentState);
            return CurrentState;
        }

        public PatientPuzzlePrimaryActionState Disable()
        {
            CurrentState = PatientPuzzlePrimaryActionStateResolver.Disabled();
            return CurrentState;
        }

        public PatientPuzzlePrimaryActionState Reset()
        {
            CurrentState = PatientPuzzlePrimaryActionStateResolver.Initial();
            return CurrentState;
        }
    }
}
