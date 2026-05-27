namespace CyberClinic.Slices
{
    public readonly struct PatientPuzzleSliceViewModel
    {
        public PatientPuzzleSliceViewModel(
            string patientId,
            int patientSeed,
            string selectedImplantId,
            string selectedProcedureId,
            float previewSuccessChance,
            float commitSuccessChance,
            string riskBand,
            string outcomeType,
            int startingCredits,
            int endingCredits,
            int startingReputation,
            int endingReputation,
            string visualCueId,
            string audioCueId,
            string saveSummary)
        {
            PatientId = patientId;
            PatientSeed = patientSeed;
            SelectedImplantId = selectedImplantId;
            SelectedProcedureId = selectedProcedureId;
            PreviewSuccessChance = previewSuccessChance;
            CommitSuccessChance = commitSuccessChance;
            RiskBand = riskBand;
            OutcomeType = outcomeType;
            StartingCredits = startingCredits;
            EndingCredits = endingCredits;
            StartingReputation = startingReputation;
            EndingReputation = endingReputation;
            VisualCueId = visualCueId;
            AudioCueId = audioCueId;
            SaveSummary = saveSummary;
        }

        public string PatientId { get; }
        public int PatientSeed { get; }
        public string SelectedImplantId { get; }
        public string SelectedProcedureId { get; }
        public float PreviewSuccessChance { get; }
        public float CommitSuccessChance { get; }
        public string RiskBand { get; }
        public string OutcomeType { get; }
        public int StartingCredits { get; }
        public int EndingCredits { get; }
        public int StartingReputation { get; }
        public int EndingReputation { get; }
        public string VisualCueId { get; }
        public string AudioCueId { get; }
        public string SaveSummary { get; }
        public int CreditsDelta => EndingCredits - StartingCredits;
        public int ReputationDelta => EndingReputation - StartingReputation;

        public bool HasRequiredDebugData()
        {
            return
                !string.IsNullOrWhiteSpace(PatientId) &&
                PatientSeed != 0 &&
                !string.IsNullOrWhiteSpace(SelectedImplantId) &&
                !string.IsNullOrWhiteSpace(SelectedProcedureId) &&
                !string.IsNullOrWhiteSpace(RiskBand) &&
                !string.IsNullOrWhiteSpace(OutcomeType) &&
                !string.IsNullOrWhiteSpace(VisualCueId) &&
                !string.IsNullOrWhiteSpace(AudioCueId) &&
                !string.IsNullOrWhiteSpace(SaveSummary);
        }
    }
}
