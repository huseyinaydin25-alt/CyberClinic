using CyberClinic.Localization;

namespace CyberClinic.Procedures
{
    /// <summary>Localization key conventions for procedure data. Keys only; never player-facing text.</summary>
    internal static class ProcedureLocalizationKeys
    {
        public static LocalizationKey ProcedureName(string procedureId) =>
            new LocalizationKey($"procedure.{procedureId}.name");

        public static LocalizationKey ProcedureDescription(string procedureId) =>
            new LocalizationKey($"procedure.{procedureId}.description");

        public static LocalizationKey CompatibilityLabel(string compatibilityId) =>
            new LocalizationKey($"procedure.compatibility.{compatibilityId}.label");
    }
}
