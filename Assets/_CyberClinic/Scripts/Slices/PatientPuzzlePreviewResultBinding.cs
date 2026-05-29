namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzlePreviewResultBinding
    {
        public PatientPuzzlePreviewResultBinding(
            PatientPuzzleSessionState sessionState,
            float previewSuccessChance,
            string riskBand,
            string feedbackRouteId,
            string readoutVisualTokenId,
            PatientPuzzleShellPresentation presentation)
        {
            SessionState = sessionState;
            PreviewSuccessChance = previewSuccessChance;
            RiskBand = riskBand;
            FeedbackRouteId = feedbackRouteId;
            ReadoutVisualTokenId = readoutVisualTokenId;
            Presentation = presentation;
        }

        public PatientPuzzleSessionState SessionState { get; }
        public float PreviewSuccessChance { get; }
        public string RiskBand { get; }
        public string FeedbackRouteId { get; }
        public string ReadoutVisualTokenId { get; }
        public PatientPuzzleShellPresentation Presentation { get; }
    }

    public static class PatientPuzzlePreviewResultBinder
    {
        public static PatientPuzzlePreviewResultBinding Bind(PatientPuzzleSessionState sessionState)
        {
            var readout = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(sessionState.PrimaryActionState);
            var presentation = PatientPuzzleShellPresenter.Present(
                sessionState.ScreenModel,
                sessionState.PrimaryActionState);

            return new PatientPuzzlePreviewResultBinding(
                sessionState,
                sessionState.ScreenModel.RiskAnalysis.PreviewSuccessChance,
                sessionState.ScreenModel.RiskAnalysis.RiskBand,
                sessionState.LastFeedbackRoute.RouteId,
                readout.VisualTokenId,
                presentation);
        }
    }
}
