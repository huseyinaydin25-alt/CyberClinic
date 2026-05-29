namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzleSessionState
    {
        public PatientPuzzleSessionState(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState primaryActionState,
            string lastInteractionId,
            PatientPuzzlePrimaryActionFeedbackRoute lastFeedbackRoute,
            bool hasPreviewed,
            bool hasCommitted,
            bool isLocked)
        {
            ScreenModel = screenModel;
            PrimaryActionState = primaryActionState;
            LastInteractionId = lastInteractionId;
            LastFeedbackRoute = lastFeedbackRoute;
            HasPreviewed = hasPreviewed;
            HasCommitted = hasCommitted;
            IsLocked = isLocked;
        }

        public PatientPuzzleSliceScreenModel ScreenModel { get; }
        public PatientPuzzlePrimaryActionState PrimaryActionState { get; }
        public string LastInteractionId { get; }
        public PatientPuzzlePrimaryActionFeedbackRoute LastFeedbackRoute { get; }
        public bool HasPreviewed { get; }
        public bool HasCommitted { get; }
        public bool IsLocked { get; }

        public static PatientPuzzleSessionState CreateInitial(PatientPuzzleSliceScreenModel screenModel)
        {
            var primaryActionState = PatientPuzzlePrimaryActionStateResolver.Initial();
            return new PatientPuzzleSessionState(
                screenModel,
                primaryActionState,
                "patient_puzzle.session.initial",
                PatientPuzzlePrimaryActionFeedbackRouter.Route(primaryActionState),
                false,
                false,
                false);
        }

        public PatientPuzzleSessionState WithInteraction(
            string interactionId,
            PatientPuzzlePrimaryActionState primaryActionState)
        {
            return new PatientPuzzleSessionState(
                ScreenModel,
                primaryActionState,
                interactionId,
                PatientPuzzlePrimaryActionFeedbackRouter.Route(primaryActionState),
                HasPreviewed || primaryActionState.PreviewState == PreviewActionState.Previewed,
                HasCommitted || primaryActionState.CommitState == CommitActionState.Committed,
                IsLocked || primaryActionState.CommitState == CommitActionState.Committed);
        }

        public PatientPuzzleSessionState WithLockedDisabled(string interactionId)
        {
            var disabledState = PatientPuzzlePrimaryActionStateResolver.Disabled();
            return new PatientPuzzleSessionState(
                ScreenModel,
                disabledState,
                interactionId,
                PatientPuzzlePrimaryActionFeedbackRouter.Route(disabledState),
                HasPreviewed,
                HasCommitted,
                true);
        }

        public PatientPuzzleSessionState Reset()
        {
            return CreateInitial(ScreenModel);
        }
    }
}
