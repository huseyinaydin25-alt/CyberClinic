using System.Globalization;

namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzleShellPresentation
    {
        public PatientPuzzleShellPresentation(
            string patientDossierBody,
            string procedureDecisionBody,
            string riskAnalysisBody,
            string operationResultBody,
            string actionFeedbackBody,
            string primaryActionBody,
            PatientPuzzlePrimaryActionState primaryActionState)
        {
            PatientDossierBody = patientDossierBody;
            ProcedureDecisionBody = procedureDecisionBody;
            RiskAnalysisBody = riskAnalysisBody;
            OperationResultBody = operationResultBody;
            ActionFeedbackBody = actionFeedbackBody;
            PrimaryActionBody = primaryActionBody;
            PrimaryActionState = primaryActionState;
        }

        public string PatientDossierBody { get; }
        public string ProcedureDecisionBody { get; }
        public string RiskAnalysisBody { get; }
        public string OperationResultBody { get; }
        public string ActionFeedbackBody { get; }
        public string PrimaryActionBody { get; }
        public PatientPuzzlePrimaryActionState PrimaryActionState { get; }

        public bool HasRequiredDebugData()
        {
            return
                !string.IsNullOrWhiteSpace(PatientDossierBody) &&
                !string.IsNullOrWhiteSpace(ProcedureDecisionBody) &&
                !string.IsNullOrWhiteSpace(RiskAnalysisBody) &&
                !string.IsNullOrWhiteSpace(OperationResultBody) &&
                !string.IsNullOrWhiteSpace(ActionFeedbackBody) &&
                !string.IsNullOrWhiteSpace(PrimaryActionBody) &&
                HasDefaultPrimaryActionState();
        }

        public bool HasDefaultPrimaryActionState()
        {
            return
                PrimaryActionState.PreviewState == PreviewActionState.Available &&
                PrimaryActionState.CommitState == CommitActionState.Available;
        }

        public bool HasPrimaryActionState(PatientPuzzlePrimaryActionState expectedState)
        {
            return
                PrimaryActionState.PreviewState == expectedState.PreviewState &&
                PrimaryActionState.CommitState == expectedState.CommitState;
        }
    }

    public static class PatientPuzzleShellPresenter
    {
        public static PatientPuzzleShellPresentation Present(PatientPuzzleSliceScreenModel screenModel)
        {
            return Present(screenModel, PatientPuzzlePrimaryActionStateResolver.Initial());
        }

        public static PatientPuzzleShellPresentation Present(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState primaryActionState)
        {
            return new PatientPuzzleShellPresentation(
                BuildPatientDossierText(screenModel.PatientDossier),
                BuildProcedureDecisionText(screenModel.ProcedureDecision),
                BuildRiskAnalysisText(screenModel.RiskAnalysis),
                BuildOperationResultText(screenModel.OperationResult),
                BuildActionFeedbackText(screenModel.ActionFeedback),
                BuildPrimaryActionText(screenModel.RiskAnalysis, primaryActionState),
                primaryActionState);
        }

        static string BuildPatientDossierText(PatientDossierSection section)
        {
            return "debug.patientId=" + section.PatientId + "\n" +
                   "debug.patientSeed=" + section.PatientSeed + "\n" +
                   PatientPuzzleShellLocalizationKeys.PatientProfilePending;
        }

        static string BuildProcedureDecisionText(ProcedureDecisionSection section)
        {
            return "debug.selectedImplantId=" + section.SelectedImplantId + "\n" +
                   "debug.selectedProcedureId=" + section.SelectedProcedureId + "\n" +
                   PatientPuzzleShellLocalizationKeys.ImplantProcedureCardsPending;
        }

        static string BuildRiskAnalysisText(RiskAnalysisSection section)
        {
            return "debug.previewSuccessChance=" + FormatChance(section.PreviewSuccessChance) + "\n" +
                   "debug.commitSuccessChance=" + FormatChance(section.CommitSuccessChance) + "\n" +
                   "debug.riskBand=" + section.RiskBand + "\n" +
                   "debug.outcomeType=" + section.OutcomeType;
        }

        static string BuildOperationResultText(OperationResultSection section)
        {
            return "debug.outcomeType=" + section.OutcomeType + "\n" +
                   "debug.creditsDelta=" + FormatDelta(section.CreditsDelta) + "\n" +
                   "debug.reputationDelta=" + FormatDelta(section.ReputationDelta) + "\n" +
                   "debug.saveSummary=" + section.SaveSummary;
        }

        static string BuildActionFeedbackText(ActionFeedbackSection section)
        {
            return "debug.visualCueId=" + section.VisualCueId + "\n" +
                   "debug.audioCueId=" + section.AudioCueId + "\n" +
                   PatientPuzzleShellLocalizationKeys.FeedbackRoutingPending;
        }

        static string BuildPrimaryActionText(RiskAnalysisSection section, PatientPuzzlePrimaryActionState primaryActionState)
        {
            return "debug.previewActionState=" + primaryActionState.PreviewState + "\n" +
                   "debug.commitActionState=" + primaryActionState.CommitState + "\n" +
                   "debug.previewSuccessChance=" + FormatChance(section.PreviewSuccessChance) + "\n" +
                   "debug.commitSuccessChance=" + FormatChance(section.CommitSuccessChance) + "\n" +
                   PatientPuzzleShellLocalizationKeys.PreviewActionPlaceholder + "\n" +
                   PatientPuzzleShellLocalizationKeys.CommitActionPlaceholder;
        }

        static string FormatChance(float value)
        {
            return value.ToString("F3", CultureInfo.InvariantCulture);
        }

        static string FormatDelta(int value)
        {
            return value >= 0 ? "+" + value : value.ToString();
        }
    }
}
