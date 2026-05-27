namespace CyberClinic.Slices
{
    public static class PatientPuzzleSliceViewModelBuilder
    {
        public static PatientPuzzleSliceViewModel FromReport(PatientPuzzleSliceReport report)
        {
            return new PatientPuzzleSliceViewModel(
                report.PatientId,
                report.PatientSeed,
                report.SelectedImplantId,
                report.SelectedProcedureId,
                report.PreviewSuccessChance,
                report.CommitSuccessChance,
                report.RiskBand,
                report.OutcomeType,
                report.StartingCredits,
                report.EndingCredits,
                report.StartingReputation,
                report.EndingReputation,
                report.VisualCueId,
                report.AudioCueId,
                report.SaveSummary);
        }

        public static PatientPuzzleSliceViewModel BuildDebugViewModel()
        {
            return FromReport(PatientPuzzleSliceRunner.RunDebugSlice());
        }
    }
}
