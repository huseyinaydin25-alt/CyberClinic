using System;

namespace CyberClinic.Progression
{
    [Serializable]
    public class PlayerProgressionState
    {
        public int TotalOperationsCompleted;
        public int TotalPatientsAccepted;
        public float LifetimeReputationEarned;
    }
}
