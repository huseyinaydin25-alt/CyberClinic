namespace CyberClinic.Online
{
    public interface IOnlineService
    {
        OnlineConfigData GetConfig();
        void PutSnapshot(OnlineSaveSnapshot snapshot);
        bool TryGetSnapshot(string playerId, out OnlineSaveSnapshot snapshot);
        OnlineRankEntry[] GetRanks();
    }
}
