using System;
using CyberClinic.Economy;

namespace CyberClinic.Save
{
    [Serializable]
    public class SaveGameData
    {
        public int SchemaVersion = SaveSchemaVersion.Current;
        public string SchemaLabel = SaveSchemaVersion.CurrentLabel;
        public ClinicEconomyState Economy = new ClinicEconomyState();
        public int CurrentDayIndex;
        public string[] OwnedCosmeticIds = Array.Empty<string>();
        public string ActiveClinicThemeId;
    }
}
