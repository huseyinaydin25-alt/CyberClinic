using System;
using CyberClinic.Procedures;

namespace CyberClinic.Audio
{
    [Serializable]
    public struct ClinicAudioRequest
    {
        public ClinicAudioEventId EventId;
        public ClinicAudioCategory Category;
        public OperationRiskBand RiskBand;
        public OperationOutcomeType OutcomeType;
        public float Intensity01;
        public string SourceId;

        public ClinicAudioRequest(
            ClinicAudioEventId eventId,
            ClinicAudioCategory category,
            OperationRiskBand riskBand,
            OperationOutcomeType outcomeType,
            float intensity01,
            string sourceId)
        {
            EventId = eventId;
            Category = category;
            RiskBand = riskBand;
            OutcomeType = outcomeType;
            Intensity01 = Math.Clamp(intensity01, 0f, 1f);
            SourceId = sourceId ?? string.Empty;
        }
    }
}
