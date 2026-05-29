namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzleCommitActionDebugInteractionResult
    {
        public PatientPuzzleCommitActionDebugInteractionResult(
            string interactionId,
            PatientPuzzlePrimaryActionState state,
            PatientPuzzleShellPresentation presentation)
        {
            InteractionId = interactionId;
            State = state;
            Presentation = presentation;
        }

        public string InteractionId { get; }
        public PatientPuzzlePrimaryActionState State { get; }
        public PatientPuzzleShellPresentation Presentation { get; }
    }

    public sealed class PatientPuzzleCommitActionDebugInteraction
    {
        readonly PatientPuzzleSliceScreenModel _screenModel;
        readonly PatientPuzzlePrimaryActionInteractionBridge _bridge;

        public PatientPuzzleCommitActionDebugInteraction(PatientPuzzleSliceScreenModel screenModel)
            : this(screenModel, new PatientPuzzlePrimaryActionInteractionBridge())
        {
        }

        public PatientPuzzleCommitActionDebugInteraction(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionInteractionBridge bridge)
        {
            _screenModel = screenModel;
            _bridge = bridge;
        }

        public PatientPuzzleCommitActionDebugInteractionResult Execute()
        {
            var interaction = _bridge.Commit();
            var presentation = PatientPuzzleShellPresenter.Present(_screenModel, interaction.State);
            return new PatientPuzzleCommitActionDebugInteractionResult(
                interaction.InteractionId,
                interaction.State,
                presentation);
        }
    }
}
