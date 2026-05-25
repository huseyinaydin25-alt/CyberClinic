using CyberClinic.Localization;

namespace CyberClinic.Patients
{
    /// <summary>Localization key conventions for patient generation (keys only, never display text).</summary>
    internal static class PatientLocalizationKeys
    {
        public static LocalizationKey ArchetypeName(string archetypeId) =>
            new LocalizationKey($"patient.archetype.{archetypeId}.name");

        public static LocalizationKey RequestDescription(string requestId) =>
            new LocalizationKey($"patient.request.{requestId}.description");

        public static LocalizationKey MotivationHint(string motivationId) =>
            new LocalizationKey($"patient.motivation.{motivationId}.hint");

        public static LocalizationKey BudgetBand(BudgetBandId band) =>
            new LocalizationKey($"patient.budget.{BudgetBandToKeySegment(band)}.label");

        public static LocalizationKey UrgencyLevel(PatientUrgencyLevel level) =>
            new LocalizationKey($"patient.urgency.{UrgencyLevelToKeySegment(level)}.label");

        static string BudgetBandToKeySegment(BudgetBandId band) => band switch
        {
            BudgetBandId.Broke => "broke",
            BudgetBandId.Tight => "tight",
            BudgetBandId.Standard => "standard",
            BudgetBandId.Flush => "flush",
            BudgetBandId.Suspicious => "suspicious",
            _ => "standard"
        };

        static string UrgencyLevelToKeySegment(PatientUrgencyLevel level) => level switch
        {
            PatientUrgencyLevel.Low => "low",
            PatientUrgencyLevel.Medium => "medium",
            PatientUrgencyLevel.High => "high",
            PatientUrgencyLevel.Critical => "critical",
            _ => "medium"
        };
    }

    internal enum BudgetBandId
    {
        Broke = 0,
        Tight = 1,
        Standard = 2,
        Flush = 3,
        Suspicious = 4
    }
}
