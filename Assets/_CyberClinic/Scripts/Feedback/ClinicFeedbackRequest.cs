using System;
using CyberClinic.Procedures;

namespace CyberClinic.Feedback
{
    [Serializable]
    public struct ClinicFeedbackRequest
    {
        public ClinicFeedbackEventId EventId;
        public OperationRiskBand RiskBand;
        public OperationOutcomeType OutcomeType;
        public float Intensity01;
        public string SourceId;

        public ClinicFeedbackRequest(
            ClinicFeedbackEventId eventId,
            OperationRiskBand riskBand,
            OperationOutcomeType outcomeType,
            float intensity01,
            string sourceId)
        {
            EventId = eventId;
            RiskBand = riskBand;
            OutcomeType = outcomeType;
            Intensity01 = Math.Clamp(intensity01, 0f, 1f);
            SourceId = sourceId ?? string.Empty;
        }
    }
}
