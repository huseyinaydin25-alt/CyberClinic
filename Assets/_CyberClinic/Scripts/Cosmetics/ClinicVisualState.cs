using System;

namespace CyberClinic.Cosmetics
{
    [Serializable]
    public class ClinicVisualState
    {
        public ClinicTier CurrentTier = ClinicTier.BackAlley;
        public string ActiveClinicThemeId;
        public string ActiveUiThemeId;
        public string ActiveScanVisualId;
        public string ActiveAmbienceThemeId;
        public string ActiveSeasonalThemeId;
    }
}
