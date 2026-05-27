using System.Collections.Generic;

namespace CyberClinic.Online
{
    public sealed class MockOnlineService : IOnlineService
    {
        readonly Dictionary<string, OnlineSaveSnapshot> _snapshots = new Dictionary<string, OnlineSaveSnapshot>();
        readonly OnlineRankEntry[] _ranks;
        readonly OnlineConfigData _config;

        public int SnapshotCount => _snapshots.Count;

        public MockOnlineService()
        {
            _config = new OnlineConfigData
            {
                ConfigVersion = "test_config_1",
                EventsEnabled = true,
                DailyPatientCount = 3,
                ActiveEventId = "test_event_none"
            };

            _ranks = new[]
            {
                new OnlineRankEntry { PlayerId = "debug_player", NameKey = "player.debug", Value = 1200, Position = 1 }
            };
        }

        public OnlineConfigData GetConfig()
        {
            return _config;
        }

        public void PutSnapshot(OnlineSaveSnapshot snapshot)
        {
            if (snapshot == null || string.IsNullOrWhiteSpace(snapshot.PlayerId))
            {
                return;
            }

            _snapshots[snapshot.PlayerId] = snapshot;
        }

        public bool TryGetSnapshot(string playerId, out OnlineSaveSnapshot snapshot)
        {
            snapshot = null;
            return !string.IsNullOrWhiteSpace(playerId) && _snapshots.TryGetValue(playerId, out snapshot);
        }

        public OnlineRankEntry[] GetRanks()
        {
            return _ranks;
        }
    }
}
