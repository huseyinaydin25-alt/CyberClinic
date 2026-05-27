namespace CyberClinic.Slices
{
    public static class PatientPuzzleShellLocalizationKeys
    {
        public const string ShellTitle = "ui.shell.patient_puzzle.title";
        public const string ShellSubtitlePlaceholder = "ui.shell.patient_puzzle.subtitle.placeholder";
        public const string PatientDossierTitle = "ui.shell.patient_dossier.title";
        public const string ProcedureDecisionTitle = "ui.shell.procedure_decision.title";
        public const string RiskAnalysisTitle = "ui.shell.risk_analysis.title";
        public const string OperationResultTitle = "ui.shell.operation_result.title";
        public const string ActionFeedbackTitle = "ui.shell.action_feedback.title";
        public const string FooterPlaceholder = "ui.shell.placeholder.footer";
        public const string PatientProfilePending = "ui.placeholder.patient_profile_pending";
        public const string ImplantProcedureCardsPending = "ui.placeholder.implant_procedure_cards_pending";
        public const string FeedbackRoutingPending = "ui.placeholder.feedback_routing_pending";

        public static bool HasRequiredKeys()
        {
            return
                HasValue(ShellTitle) &&
                HasValue(ShellSubtitlePlaceholder) &&
                HasValue(PatientDossierTitle) &&
                HasValue(ProcedureDecisionTitle) &&
                HasValue(RiskAnalysisTitle) &&
                HasValue(OperationResultTitle) &&
                HasValue(ActionFeedbackTitle) &&
                HasValue(FooterPlaceholder) &&
                HasValue(PatientProfilePending) &&
                HasValue(ImplantProcedureCardsPending) &&
                HasValue(FeedbackRoutingPending);
        }

        static bool HasValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
