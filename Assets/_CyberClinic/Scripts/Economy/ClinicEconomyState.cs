using System;

namespace CyberClinic.Economy
{
    [Serializable]
    public class ClinicEconomyState
    {
        public int Credits;
        public int Reputation;
        public int DayIndex;

        public ClinicEconomyState Clone()
        {
            return new ClinicEconomyState
            {
                Credits = Credits,
                Reputation = Reputation,
                DayIndex = DayIndex
            };
        }
    }
}
