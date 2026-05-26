using CyberClinic.Localization;

namespace CyberClinic.Implants
{
    /// <summary>Localization key conventions for implant data. Keys only; never player-facing text.</summary>
    internal static class ImplantLocalizationKeys
    {
        public static LocalizationKey ImplantName(string implantId) =>
            new LocalizationKey($"implant.{implantId}.name");

        public static LocalizationKey ImplantDescription(string implantId) =>
            new LocalizationKey($"implant.{implantId}.description");

        public static LocalizationKey CompatibilityLabel(string ruleId) =>
            new LocalizationKey($"implant.compatibility.{ruleId}.label");

        public static LocalizationKey CompatibilityDescription(string ruleId) =>
            new LocalizationKey($"implant.compatibility.{ruleId}.description");

        public static LocalizationKey VisualVariantLabel(string variantId) =>
            new LocalizationKey($"implant.visual_variant.{variantId}.label");
    }
}
