namespace CyberClinic.Patients
{
    public struct PatientGenerationResult
    {
        public bool Success;
        public GeneratedPatient Patient;
        public PatientGenerationError Error;
        public string TechnicalMessage;

        public static PatientGenerationResult Succeeded(GeneratedPatient patient) =>
            new PatientGenerationResult
            {
                Success = true,
                Patient = patient,
                Error = PatientGenerationError.None,
                TechnicalMessage = string.Empty
            };

        public static PatientGenerationResult Failed(PatientGenerationError error, string technicalMessage = null) =>
            new PatientGenerationResult
            {
                Success = false,
                Patient = null,
                Error = error,
                TechnicalMessage = technicalMessage ?? error.TechnicalMessage
            };
    }
}
