namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterSessionState
    {
        public OperationEncounterSessionState(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState actionState,
            string lastInteractionId,
            PatientPuzzlePrimaryActionFeedbackRoute lastFeedbackRoute,
            bool hasPreviewed,
            bool hasCommitted,
            bool isLocked)
        {
            ScreenModel = screenModel;
            ActionState = actionState;
            LastInteractionId = lastInteractionId;
            LastFeedbackRoute = lastFeedbackRoute;
            HasPreviewed = hasPreviewed;
            HasCommitted = hasCommitted;
            IsLocked = isLocked;
        }

        public PatientPuzzleSliceScreenModel ScreenModel { get; }
        public PatientPuzzlePrimaryActionState ActionState { get; }
        public string LastInteractionId { get; }
        public PatientPuzzlePrimaryActionFeedbackRoute LastFeedbackRoute { get; }
        public bool HasPreviewed { get; }
        public bool HasCommitted { get; }
        public bool IsLocked { get; }

        public static OperationEncounterSessionState CreateInitial(PatientPuzzleSliceScreenModel screenModel)
        {
            var actionState = PatientPuzzlePrimaryActionStateResolver.Initial();
            return new OperationEncounterSessionState(
                screenModel,
                actionState,
                "operation_encounter.session.initial",
                PatientPuzzlePrimaryActionFeedbackRouter.Route(actionState),
                false,
                false,
                false);
        }

        public OperationEncounterSessionState WithInteraction(
            string interactionId,
            PatientPuzzlePrimaryActionState actionState)
        {
            return new OperationEncounterSessionState(
                ScreenModel,
                actionState,
                interactionId,
                PatientPuzzlePrimaryActionFeedbackRouter.Route(actionState),
                HasPreviewed || actionState.PreviewState == PreviewActionState.Previewed,
                HasCommitted || actionState.CommitState == CommitActionState.Committed,
                IsLocked || actionState.CommitState == CommitActionState.Committed);
        }

        public OperationEncounterSessionState WithLockedDisabled(string interactionId)
        {
            var disabledState = PatientPuzzlePrimaryActionStateResolver.Disabled();
            return new OperationEncounterSessionState(
                ScreenModel,
                disabledState,
                interactionId,
                PatientPuzzlePrimaryActionFeedbackRouter.Route(disabledState),
                HasPreviewed,
                HasCommitted,
                true);
        }

        public OperationEncounterSessionState Reset()
        {
            return CreateInitial(ScreenModel);
        }
    }
}
