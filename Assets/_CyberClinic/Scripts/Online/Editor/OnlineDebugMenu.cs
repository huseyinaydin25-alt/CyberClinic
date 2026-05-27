#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Online.Editor
{
    public static class OnlineDebugMenu
    {
        [MenuItem("Cyber Clinic/Online/Validate Mock Data")]
        public static void ValidateMockData()
        {
            var service = new MockOnlineService();
            var config = service.GetConfig();

            var snapshot = new OnlineSaveSnapshot
            {
                PlayerId = "debug_player",
                SchemaVersion = 1,
                JsonPayload = "debug_payload",
                UpdatedAtIso = "2026-05-27T00:00:00Z"
            };

            service.PutSnapshot(snapshot);
            var snapshotOk = service.TryGetSnapshot("debug_player", out var loadedSnapshot);
            var ranks = service.GetRanks();

            var valid =
                config != null &&
                config.ConfigVersion == "test_config_1" &&
                config.EventsEnabled &&
                config.DailyPatientCount == 3 &&
                snapshotOk &&
                loadedSnapshot != null &&
                loadedSnapshot.SchemaVersion == 1 &&
                loadedSnapshot.PlayerId == "debug_player" &&
                service.SnapshotCount == 1 &&
                ranks != null &&
                ranks.Length == 1 &&
                ranks[0].Position == 1;

            if (!valid)
            {
                Debug.LogWarning("OnlineDebug failed");
                return;
            }

            Debug.Log(
                "OnlineDebug OK\n" +
                $"configVersion={config.ConfigVersion}\n" +
                $"eventsEnabled={config.EventsEnabled}\n" +
                $"dailyPatientCount={config.DailyPatientCount}\n" +
                $"activeEventId={config.ActiveEventId}\n" +
                $"snapshotPlayerId={loadedSnapshot.PlayerId}\n" +
                $"snapshotSchemaVersion={loadedSnapshot.SchemaVersion}\n" +
                $"snapshotCount={service.SnapshotCount}\n" +
                $"rankCount={ranks.Length}\n" +
                $"topRankPlayerId={ranks[0].PlayerId}\n" +
                $"topRankValue={ranks[0].Value}");
        }
    }
}
#endif
