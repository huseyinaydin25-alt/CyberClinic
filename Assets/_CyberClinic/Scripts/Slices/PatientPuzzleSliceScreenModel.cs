namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzleSliceScreenModel
    {
        public PatientPuzzleSliceScreenModel(
            PatientDossierSection patientDossier,
            ProcedureDecisionSection procedureDecision,
            RiskAnalysisSection riskAnalysis,
            OperationResultSection operationResult,
            ActionFeedbackSection actionFeedback)
        {
            PatientDossier = patientDossier;
            ProcedureDecision = procedureDecision;
            RiskAnalysis = riskAnalysis;
            OperationResult = operationResult;
            ActionFeedback = actionFeedback;
        }

        public PatientDossierSection PatientDossier { get; }
        public ProcedureDecisionSection ProcedureDecision { get; }
        public RiskAnalysisSection RiskAnalysis { get; }
        public OperationResultSection OperationResult { get; }
        public ActionFeedbackSection ActionFeedback { get; }

        public bool HasRequiredDebugData()
        {
            return
                PatientDossier.HasRequiredDebugData() &&
                ProcedureDecision.HasRequiredDebugData() &&
                RiskAnalysis.HasRequiredDebugData() &&
                OperationResult.HasRequiredDebugData() &&
                ActionFeedback.HasRequiredDebugData();
        }
    }

    public readonly struct PatientDossierSection
    {
        public PatientDossierSection(string patientId, int patientSeed)
        {
            PatientId = patientId;
            PatientSeed = patientSeed;
        }

        public string PatientId { get; }
        public int PatientSeed { get; }

        public bool HasRequiredDebugData()
        {
            return !string.IsNullOrWhiteSpace(PatientId) && PatientSeed != 0;
        }
    }

    public readonly struct ProcedureDecisionSection
    {
        public ProcedureDecisionSection(string selectedImplantId, string selectedProcedureId)
        {
            SelectedImplantId = selectedImplantId;
            SelectedProcedureId = selectedProcedureId;
        }

        public string SelectedImplantId { get; }
        public string SelectedProcedureId { get; }

        public bool HasRequiredDebugData()
        {
            return !string.IsNullOrWhiteSpace(SelectedImplantId) && !string.IsNullOrWhiteSpace(SelectedProcedureId);
        }
    }

    public readonly struct RiskAnalysisSection
    {
        public RiskAnalysisSection(float previewSuccessChance, float commitSuccessChance, string riskBand, string outcomeType)
        {
            PreviewSuccessChance = previewSuccessChance;
            CommitSuccessChance = commitSuccessChance;
            RiskBand = riskBand;
            OutcomeType = outcomeType;
        }

        public float PreviewSuccessChance { get; }
        public float CommitSuccessChance { get; }
        public string RiskBand { get; }
        public string OutcomeType { get; }

        public bool HasRequiredDebugData()
        {
            return PreviewSuccessChance > 0f && CommitSuccessChance > 0f && !string.IsNullOrWhiteSpace(RiskBand) && !string.IsNullOrWhiteSpace(OutcomeType);
        }
    }

    public readonly struct OperationResultSection
    {
        public OperationResultSection(
            int startingCredits,
            int endingCredits,
            int startingReputation,
            int endingReputation,
            string outcomeType,
            string saveSummary)
        {
            StartingCredits = startingCredits;
            EndingCredits = endingCredits;
            StartingReputation = startingReputation;
            EndingReputation = endingReputation;
            OutcomeType = outcomeType;
            SaveSummary = saveSummary;
        }

        public int StartingCredits { get; }
        public int EndingCredits { get; }
        public int StartingReputation { get; }
        public int EndingReputation { get; }
        public int CreditsDelta => EndingCredits - StartingCredits;
        public int ReputationDelta => EndingReputation - StartingReputation;
        public string OutcomeType { get; }
        public string SaveSummary { get; }

        public bool HasRequiredDebugData()
        {
            return !string.IsNullOrWhiteSpace(OutcomeType) && !string.IsNullOrWhiteSpace(SaveSummary);
        }
    }

    public readonly struct ActionFeedbackSection
    {
        public ActionFeedbackSection(string visualCueId, string audioCueId)
        {
            VisualCueId = visualCueId;
            AudioCueId = audioCueId;
        }

        public string VisualCueId { get; }
        public string AudioCueId { get; }

        public bool HasRequiredDebugData()
        {
            return !string.IsNullOrWhiteSpace(VisualCueId) && !string.IsNullOrWhiteSpace(AudioCueId);
        }
    }
}
