#if UNITY_EDITOR
using System.IO;
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
            var data = CreateData();
            const string slotId = "debug_slot_0";
            var memoryOk = ValidateStorage(new InMemorySaveStorage(), slotId, data, out var loaded, out var jsonLength);

            var tempRoot = Path.Combine(Application.temporaryCachePath, "CyberClinicSaveDebug");
            var fileStorage = new LocalFileSaveStorage(tempRoot);
            var fileOk = ValidateStorage(fileStorage, slotId, data, out var fileLoaded, out var fileJsonLength);

            if (!memoryOk || !fileOk)
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
                $"memoryJsonLength={jsonLength}\n" +
                $"fileJsonLength={fileJsonLength}\n" +
                $"fileCurrentDayIndex={fileLoaded.CurrentDayIndex}\n" +
                $"deleted=True");
        }

        static SaveGameData CreateData()
        {
            return new SaveGameData
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
        }

        static bool ValidateStorage(ISaveStorage storage, string slotId, SaveGameData data, out SaveGameData loaded, out int jsonLength)
        {
            loaded = null;
            var service = new SaveService(storage);
            service.Save(slotId, data);
            var loadedOk = service.TryLoad(slotId, out loaded);
            var json = SaveSerializer.ToJson(data);
            jsonLength = json.Length;
            service.Delete(slotId);

            return loadedOk &&
                   loaded != null &&
                   loaded.SchemaVersion == SaveSchemaVersion.Current &&
                   loaded.CurrentDayIndex == 5 &&
                   loaded.Economy != null &&
                   loaded.Economy.Credits == 635 &&
                   loaded.Economy.Reputation == 43 &&
                   loaded.OwnedCosmeticIds != null &&
                   loaded.OwnedCosmeticIds.Length == 2 &&
                   !service.HasSave(slotId);
        }
    }
}
#endif
