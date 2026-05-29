namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzlePreviewActionDebugInteractionResult
    {
        public PatientPuzzlePreviewActionDebugInteractionResult(
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

    public sealed class PatientPuzzlePreviewActionDebugInteraction
    {
        readonly PatientPuzzleSliceScreenModel _screenModel;
        readonly PatientPuzzlePrimaryActionInteractionBridge _bridge;

        public PatientPuzzlePreviewActionDebugInteraction(PatientPuzzleSliceScreenModel screenModel)
            : this(screenModel, new PatientPuzzlePrimaryActionInteractionBridge())
        {
        }

        public PatientPuzzlePreviewActionDebugInteraction(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionInteractionBridge bridge)
        {
            _screenModel = screenModel;
            _bridge = bridge;
        }

        public PatientPuzzlePreviewActionDebugInteractionResult Execute()
        {
            var interaction = _bridge.Preview();
            var presentation = PatientPuzzleShellPresenter.Present(_screenModel, interaction.State);
            return new PatientPuzzlePreviewActionDebugInteractionResult(
                interaction.InteractionId,
                interaction.State,
                presentation);
        }
    }
}
