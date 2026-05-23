using System;

namespace CyberClinic.Backend
{
    [Serializable]
    public class LiveEventInfo
    {
        public string EventId;
        public DateTime StartsAtUtc;
        public DateTime EndsAtUtc;
        public bool IsActive;
    }
}
