namespace CyberClinic.Core
{
    /// <summary>
    /// Global tuning constants and module boundaries (not player-facing text).
    /// </summary>
    public static class CyberClinicConstants
    {
        public const string ContentRootMenu = "Cyber Clinic/";

        /// <summary>Initial save format version for Milestone 10.</summary>
        public const int InitialSaveVersion = 1;

        /// <summary>Typical seeded operation variance band (tune via EconomyTuningData later).</summary>
        public const float DefaultOperationVarianceHalfRange = 0.05f;
    }
}
