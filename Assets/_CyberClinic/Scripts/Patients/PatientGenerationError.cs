namespace CyberClinic.Patients
{
    /// <summary>Structured generation failure codes (technical, not player-facing).</summary>
    public enum PatientGenerationErrorCode
    {
        None = 0,
        NullInput = 1,
        MissingArchetypes = 2,
        MissingMotivations = 3,
        MissingRequestTypes = 4,
        MissingHiddenConditions = 5,
        MissingVisualTraits = 6,
        MissingDialogueTones = 7,
        InvalidDefinitionId = 8,
        MissingLocalizationKey = 9,
        EmptyFilteredPool = 10,
        TutorialConstraintPoolEmpty = 11
    }

    public struct PatientGenerationError
    {
        public PatientGenerationErrorCode Code;
        public string TechnicalMessage;

        public bool IsNone => Code == PatientGenerationErrorCode.None;

        public static PatientGenerationError None => new PatientGenerationError
        {
            Code = PatientGenerationErrorCode.None,
            TechnicalMessage = string.Empty
        };

        public static PatientGenerationError Create(PatientGenerationErrorCode code, string technicalMessage) =>
            new PatientGenerationError { Code = code, TechnicalMessage = technicalMessage ?? string.Empty };
    }
}
