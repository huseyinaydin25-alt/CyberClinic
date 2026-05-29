namespace CyberClinic.Slices
{
    public sealed class OperationEncounterSessionController
    {
        public OperationEncounterSessionController(PatientPuzzleSliceScreenModel screenModel)
            : this(OperationEncounterSessionState.CreateInitial(screenModel))
        {
        }

        public OperationEncounterSessionController(OperationEncounterSessionState initialState)
        {
            CurrentState = initialState;
        }

        public OperationEncounterSessionState CurrentState { get; private set; }

        public OperationEncounterSessionState Plan()
        {
            if (CurrentState.IsLocked)
            {
                return CurrentState;
            }

            var nextState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(CurrentState.ActionState);
            CurrentState = CurrentState.WithInteraction("operation_action.plan", nextState);
            return CurrentState;
        }

        public OperationEncounterSessionState Execute()
        {
            if (CurrentState.IsLocked)
            {
                return CurrentState;
            }

            var nextState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(CurrentState.ActionState);
            CurrentState = CurrentState.WithInteraction("operation_action.execute", nextState);
            return CurrentState;
        }

        public OperationEncounterSessionState Disable()
        {
            if (CurrentState.IsLocked &&
                CurrentState.ActionState.PreviewState == PreviewActionState.Disabled &&
                CurrentState.ActionState.CommitState == CommitActionState.Disabled)
            {
                return CurrentState;
            }

            CurrentState = CurrentState.WithLockedDisabled("operation_action.disable");
            return CurrentState;
        }

        public OperationEncounterSessionState Reset()
        {
            CurrentState = CurrentState.Reset();
            return CurrentState;
        }
    }
}
