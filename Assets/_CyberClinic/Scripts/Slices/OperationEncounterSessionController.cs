namespace CyberClinic.Slices
{
    public sealed class OperationEncounterSessionController
    {
        readonly PatientPuzzleSessionController _legacyController;

        public OperationEncounterSessionController(PatientPuzzleSliceScreenModel screenModel)
            : this(new PatientPuzzleSessionController(screenModel))
        {
        }

        public OperationEncounterSessionController(PatientPuzzleSessionController legacyController)
        {
            _legacyController = legacyController;
        }

        public OperationEncounterSessionState CurrentState => new OperationEncounterSessionState(_legacyController.CurrentState);

        public OperationEncounterSessionState Preview()
        {
            return new OperationEncounterSessionState(_legacyController.Preview());
        }

        public OperationEncounterSessionState Commit()
        {
            return new OperationEncounterSessionState(_legacyController.Commit());
        }

        public OperationEncounterSessionState Disable()
        {
            return new OperationEncounterSessionState(_legacyController.Disable());
        }

        public OperationEncounterSessionState Reset()
        {
            return new OperationEncounterSessionState(_legacyController.Reset());
        }
    }
}
