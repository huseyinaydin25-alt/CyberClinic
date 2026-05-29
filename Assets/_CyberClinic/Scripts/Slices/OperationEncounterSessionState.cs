namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterSessionState
    {
        readonly PatientPuzzleSessionState _legacyState;

        public OperationEncounterSessionState(PatientPuzzleSessionState legacyState)
        {
            _legacyState = legacyState;
        }

        public PatientPuzzleSessionState LegacyState => _legacyState;
        public PatientPuzzleSliceScreenModel ScreenModel => _legacyState.ScreenModel;
        public PatientPuzzlePrimaryActionState ActionState => _legacyState.PrimaryActionState;
        public string LastInteractionId => _legacyState.LastInteractionId;
        public PatientPuzzlePrimaryActionFeedbackRoute LastFeedbackRoute => _legacyState.LastFeedbackRoute;
        public bool HasPreviewed => _legacyState.HasPreviewed;
        public bool HasCommitted => _legacyState.HasCommitted;
        public bool IsLocked => _legacyState.IsLocked;

        public static OperationEncounterSessionState CreateInitial(PatientPuzzleSliceScreenModel screenModel)
        {
            return new OperationEncounterSessionState(PatientPuzzleSessionState.CreateInitial(screenModel));
        }

        public OperationEncounterSessionState WithInteraction(
            string interactionId,
            PatientPuzzlePrimaryActionState actionState)
        {
            return new OperationEncounterSessionState(_legacyState.WithInteraction(interactionId, actionState));
        }

        public OperationEncounterSessionState WithLockedDisabled(string interactionId)
        {
            return new OperationEncounterSessionState(_legacyState.WithLockedDisabled(interactionId));
        }

        public OperationEncounterSessionState Reset()
        {
            return new OperationEncounterSessionState(_legacyState.Reset());
        }
    }
}
