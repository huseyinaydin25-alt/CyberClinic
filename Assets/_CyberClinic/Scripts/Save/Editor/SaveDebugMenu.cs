#if UNITY_EDITOR
using CyberClinic.Economy;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Save.Editor
{
    public static class SaveDebugMenu
    {
        [MenuItem("Cyber Clinic/Save/Run Save Debug")]
        public static void RunSaveDebug()
        {
            var storage = new InMemorySaveStorage();
            var service = new SaveService(storage);
            const string slotId = "debug_slot_0";

            var data = new SaveGameData
            {
                CurrentDayIndex = 5,
                Economy = new ClinicEconomyState
                {
                    Credits = 635,
                    Reputation = 43,
                    DayIndex = 5
                },
                OwnedCosmeticIds = new[] { "test_cosmetic_a", "test_theme_a" },
                ActiveClinicThemeId = "test_theme_a"
            };

            service.Save(slotId, data);
            var loadedOk = service.TryLoad(slotId, out var loaded);
            var json = SaveSerializer.ToJson(data);
            service.Delete(slotId);

            var valid =
                loadedOk &&
                loaded != null &&
                loaded.SchemaVersion == SaveSchemaVersion.Current &&
                loaded.CurrentDayIndex == 5 &&
                loaded.Economy.Credits == 635 &&
                loaded.Economy.Reputation == 43 &&
                loaded.OwnedCosmeticIds.Length == 2 &&
                !service.HasSave(slotId);

            if (!valid)
            {
                Debug.LogWarning("SaveDebug failed");
                return;
            }

            Debug.Log(
                "SaveDebug OK\n" +
                $"schemaVersion={loaded.SchemaVersion}\n" +
                $"schemaLabel={loaded.SchemaLabel}\n" +
                $"currentDayIndex={loaded.CurrentDayIndex}\n" +
                $"credits={loaded.Economy.Credits}\n" +
                $"reputation={loaded.Economy.Reputation}\n" +
                $"ownedCosmeticCount={loaded.OwnedCosmeticIds.Length}\n" +
                $"activeClinicThemeId={loaded.ActiveClinicThemeId}\n" +
                $"jsonLength={json.Length}\n" +
                $"deleted=True");
        }
    }
}
#endif
