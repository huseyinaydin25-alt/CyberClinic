namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterPreviewResultBinding
    {
        readonly PatientPuzzlePreviewResultBinding _legacyBinding;

        public OperationEncounterPreviewResultBinding(PatientPuzzlePreviewResultBinding legacyBinding)
        {
            _legacyBinding = legacyBinding;
        }

        public PatientPuzzlePreviewResultBinding LegacyBinding => _legacyBinding;
        public OperationEncounterSessionState SessionState => new OperationEncounterSessionState(_legacyBinding.SessionState);
        public float PreviewSuccessChance => _legacyBinding.PreviewSuccessChance;
        public string RiskBand => _legacyBinding.RiskBand;
        public string FeedbackRouteId => _legacyBinding.FeedbackRouteId;
        public string ReadoutVisualTokenId => _legacyBinding.ReadoutVisualTokenId;
        public PatientPuzzleShellPresentation Presentation => _legacyBinding.Presentation;
    }

    public static class OperationEncounterPreviewResultBinder
    {
        public static OperationEncounterPreviewResultBinding Bind(OperationEncounterSessionState sessionState)
        {
            return new OperationEncounterPreviewResultBinding(
                PatientPuzzlePreviewResultBinder.Bind(sessionState.LegacyState));
        }
    }
}
