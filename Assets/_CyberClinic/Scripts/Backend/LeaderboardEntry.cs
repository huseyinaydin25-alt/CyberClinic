using System;
using CyberClinic.Localization;

namespace CyberClinic.Backend
{
    [Serializable]
    public class LeaderboardEntry
    {
        public string PlayerId;
        public LocalizationKey DisplayNameKey;
        public int Score;
        public int Rank;
    }
}
