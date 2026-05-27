using System;

namespace CyberClinic.Online
{
    [Serializable]
    public class OnlineConfigData
    {
        public string ConfigVersion;
        public bool EventsEnabled;
        public int DailyPatientCount;
        public string ActiveEventId;
    }
}
