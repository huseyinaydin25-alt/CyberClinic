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
            string primaryActionBody)
        {
            PatientDossierBody = patientDossierBody;
            ProcedureDecisionBody = procedureDecisionBody;
            RiskAnalysisBody = riskAnalysisBody;
            OperationResultBody = operationResultBody;
            ActionFeedbackBody = actionFeedbackBody;
            PrimaryActionBody = primaryActionBody;
        }

        public string PatientDossierBody { get; }
        public string ProcedureDecisionBody { get; }
        public string RiskAnalysisBody { get; }
        public string OperationResultBody { get; }
        public string ActionFeedbackBody { get; }
        public string PrimaryActionBody { get; }

        public bool HasRequiredDebugData()
        {
            return
                !string.IsNullOrWhiteSpace(PatientDossierBody) &&
                !string.IsNullOrWhiteSpace(ProcedureDecisionBody) &&
                !string.IsNullOrWhiteSpace(RiskAnalysisBody) &&
                !string.IsNullOrWhiteSpace(OperationResultBody) &&
                !string.IsNullOrWhiteSpace(ActionFeedbackBody) &&
                !string.IsNullOrWhiteSpace(PrimaryActionBody);
        }
    }

    public static class PatientPuzzleShellPresenter
    {
        public static PatientPuzzleShellPresentation Present(PatientPuzzleSliceScreenModel screenModel)
        {
            return new PatientPuzzleShellPresentation(
                BuildPatientDossierText(screenModel.PatientDossier),
                BuildProcedureDecisionText(screenModel.ProcedureDecision),
                BuildRiskAnalysisText(screenModel.RiskAnalysis),
                BuildOperationResultText(screenModel.OperationResult),
                BuildActionFeedbackText(screenModel.ActionFeedback),
                BuildPrimaryActionText(screenModel.RiskAnalysis));
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
            return "debug.previewSuccessChance=" + section.PreviewSuccessChance.ToString("F3") + "\n" +
                   "debug.commitSuccessChance=" + section.CommitSuccessChance.ToString("F3") + "\n" +
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

        static string BuildPrimaryActionText(RiskAnalysisSection section)
        {
            return "debug.previewActionState=available" + "\n" +
                   "debug.commitActionState=available" + "\n" +
                   "debug.previewSuccessChance=" + section.PreviewSuccessChance.ToString("F3") + "\n" +
                   "debug.commitSuccessChance=" + section.CommitSuccessChance.ToString("F3") + "\n" +
                   PatientPuzzleShellLocalizationKeys.PreviewActionPlaceholder + "\n" +
                   PatientPuzzleShellLocalizationKeys.CommitActionPlaceholder;
        }

        static string FormatDelta(int value)
        {
            return value >= 0 ? "+" + value : value.ToString();
        }
    }
}
