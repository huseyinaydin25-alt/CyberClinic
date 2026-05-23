namespace CyberClinic.Backend
{
    public interface ILeaderboardService
    {
        void SubmitScore(string playerId, int score);
        LeaderboardEntry[] GetTopEntries(int count);
    }
}
