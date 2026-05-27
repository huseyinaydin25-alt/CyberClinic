namespace CyberClinic.Slices
{
    public static class PatientPuzzleSliceScreenModelBuilder
    {
        public static PatientPuzzleSliceScreenModel FromViewModel(PatientPuzzleSliceViewModel viewModel)
        {
            return new PatientPuzzleSliceScreenModel(
                new PatientDossierSection(
                    viewModel.PatientId,
                    viewModel.PatientSeed),
                new ProcedureDecisionSection(
                    viewModel.SelectedImplantId,
                    viewModel.SelectedProcedureId),
                new RiskAnalysisSection(
                    viewModel.PreviewSuccessChance,
                    viewModel.CommitSuccessChance,
                    viewModel.RiskBand,
                    viewModel.OutcomeType),
                new OperationResultSection(
                    viewModel.StartingCredits,
                    viewModel.EndingCredits,
                    viewModel.StartingReputation,
                    viewModel.EndingReputation,
                    viewModel.OutcomeType,
                    viewModel.SaveSummary),
                new ActionFeedbackSection(
                    viewModel.VisualCueId,
                    viewModel.AudioCueId));
        }

        public static PatientPuzzleSliceScreenModel BuildDebugScreenModel()
        {
            return FromViewModel(PatientPuzzleSliceViewModelBuilder.BuildDebugViewModel());
        }
    }
}
