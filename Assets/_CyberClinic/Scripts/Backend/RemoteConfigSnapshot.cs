using System;
using System.Collections.Generic;

namespace CyberClinic.Backend
{
    /// <summary>DTO for remote configuration payloads (Supabase adapter in Milestone 10.6).</summary>
    [Serializable]
    public class RemoteConfigSnapshot
    {
        public string Version;
        public Dictionary<string, string> Values = new Dictionary<string, string>();
        public DateTime FetchedAtUtc;
    }
}
