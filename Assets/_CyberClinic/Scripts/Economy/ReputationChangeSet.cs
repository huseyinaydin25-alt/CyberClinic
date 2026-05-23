using System;

namespace CyberClinic.Economy
{
    [Serializable]
    public class ReputationChangeSet
    {
        public float ReputationDelta;
        public string SourceId;
    }
}
