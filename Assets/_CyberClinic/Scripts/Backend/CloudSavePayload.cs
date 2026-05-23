using System;

namespace CyberClinic.Backend
{
    [Serializable]
    public class CloudSavePayload
    {
        public string PlayerId;
        public int SaveVersion;
        public byte[] Data;
        public DateTime UpdatedAtUtc;
    }
}
