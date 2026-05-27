using System;

namespace CyberClinic.Economy
{
    [Serializable]
    public class DayFlowResult
    {
        public ClinicRuntimeState State;
        public DayReport Report;
        public string TechnicalMessage;
    }
}
