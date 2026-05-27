using System;

namespace CyberClinic.Economy
{
    [Serializable]
    public class DayReport
    {
        public int DayIndex;
        public int StartingCredits;
        public int EndingCredits;
        public int StartingReputation;
        public int EndingReputation;
        public int AcceptedPatients;
        public int CompletedOperations;
        public int FailedOperations;
        public EconomyDelta[] Deltas = Array.Empty<EconomyDelta>();
    }
}
