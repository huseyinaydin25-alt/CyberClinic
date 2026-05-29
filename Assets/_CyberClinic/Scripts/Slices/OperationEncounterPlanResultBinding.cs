namespace CyberClinic.Slices
{
    public readonly struct OperationEncounterPlanResultBinding
    {
        public OperationEncounterPlanResultBinding(
            OperationEncounterSessionState sessionState,
            float planningSuccessChance,
            string riskBand,
            string feedbackRouteId,
            string readoutVisualTokenId,
            PatientPuzzleShellPresentation presentation)
        {
            SessionState = sessionState;
            PlanningSuccessChance = planningSuccessChance;
            RiskBand = riskBand;
            FeedbackRouteId = feedbackRouteId;
            ReadoutVisualTokenId = readoutVisualTokenId;
            Presentation = presentation;
        }

        public OperationEncounterSessionState SessionState { get; }
        public float PlanningSuccessChance { get; }
        public string RiskBand { get; }
        public string FeedbackRouteId { get; }
        public string ReadoutVisualTokenId { get; }
        public PatientPuzzleShellPresentation Presentation { get; }
    }

    public static class OperationEncounterPlanResultBinder
    {
        public static OperationEncounterPlanResultBinding Bind(OperationEncounterSessionState sessionState)
        {
            var readout = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(sessionState.ActionState);
            var presentation = PatientPuzzleShellPresenter.Present(
                sessionState.ScreenModel,
                sessionState.ActionState);

            return new OperationEncounterPlanResultBinding(
                sessionState,
                sessionState.ScreenModel.RiskAnalysis.PreviewSuccessChance,
                sessionState.ScreenModel.RiskAnalysis.RiskBand,
                sessionState.LastFeedbackRoute.RouteId,
                readout.VisualTokenId,
                presentation);
        }
    }
}
