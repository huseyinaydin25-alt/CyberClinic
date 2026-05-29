namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzlePrimaryActionInteractionResult
    {
        public PatientPuzzlePrimaryActionInteractionResult(
            PatientPuzzlePrimaryActionState state,
            string interactionId)
        {
            State = state;
            InteractionId = interactionId;
        }

        public PatientPuzzlePrimaryActionState State { get; }
        public string InteractionId { get; }
    }

    public sealed class PatientPuzzlePrimaryActionInteractionBridge
    {
        readonly PatientPuzzlePrimaryActionController _controller;

        public PatientPuzzlePrimaryActionInteractionBridge()
            : this(new PatientPuzzlePrimaryActionController())
        {
        }

        public PatientPuzzlePrimaryActionInteractionBridge(PatientPuzzlePrimaryActionController controller)
        {
            _controller = controller;
        }

        public PatientPuzzlePrimaryActionState CurrentState => _controller.CurrentState;

        public PatientPuzzlePrimaryActionInteractionResult Preview()
        {
            return new PatientPuzzlePrimaryActionInteractionResult(
                _controller.Preview(),
                "primary_action.preview");
        }

        public PatientPuzzlePrimaryActionInteractionResult Commit()
        {
            return new PatientPuzzlePrimaryActionInteractionResult(
                _controller.Commit(),
                "primary_action.commit");
        }

        public PatientPuzzlePrimaryActionInteractionResult Disable()
        {
            return new PatientPuzzlePrimaryActionInteractionResult(
                _controller.Disable(),
                "primary_action.disable");
        }

        public PatientPuzzlePrimaryActionInteractionResult Reset()
        {
            return new PatientPuzzlePrimaryActionInteractionResult(
                _controller.Reset(),
                "primary_action.reset");
        }
    }
}
