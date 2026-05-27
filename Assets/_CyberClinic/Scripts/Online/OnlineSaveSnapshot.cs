using System;

namespace CyberClinic.Online
{
    [Serializable]
    public class OnlineSaveSnapshot
    {
        public string PlayerId;
        public int SchemaVersion;
        public string JsonPayload;
        public string UpdatedAtIso;
    }
}
