using System;

namespace CyberClinic.Economy
{
    [Serializable]
    public struct EconomyDelta
    {
        public int CreditsDelta;
        public int ReputationDelta;
        public string ReasonId;

        public EconomyDelta(int creditsDelta, int reputationDelta, string reasonId)
        {
            CreditsDelta = creditsDelta;
            ReputationDelta = reputationDelta;
            ReasonId = reasonId ?? string.Empty;
        }
    }
}
