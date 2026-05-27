using System;

namespace CyberClinic.Economy
{
    [Serializable]
    public class ClinicRuntimeState
    {
        public ClinicEconomyState Economy = new ClinicEconomyState();
        public bool DayActive;
        public int CurrentDayIndex;
        public int AcceptedPatientsToday;
        public int CompletedOperationsToday;
        public int FailedOperationsToday;

        public ClinicRuntimeState Clone()
        {
            return new ClinicRuntimeState
            {
                Economy = Economy != null ? Economy.Clone() : new ClinicEconomyState(),
                DayActive = DayActive,
                CurrentDayIndex = CurrentDayIndex,
                AcceptedPatientsToday = AcceptedPatientsToday,
                CompletedOperationsToday = CompletedOperationsToday,
                FailedOperationsToday = FailedOperationsToday
            };
        }
    }
}
