using CyberClinic.Core;
using CyberClinic.Procedures;
using UnityEngine;

namespace CyberClinic.Feedback
{
    [CreateAssetMenu(fileName = "ClinicFeedbackCue", menuName = "Cyber Clinic/Feedback/Cue")]
    public class ClinicFeedbackCueData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] ClinicFeedbackEventId _eventId;
        [SerializeField] ClinicFeedbackCategory _category;
        [SerializeField] OperationRiskBand _minimumRiskBand;
        [SerializeField] OperationOutcomeType _outcomeType;
        [SerializeField] string _technicalAddress;
        [SerializeField] float _durationSeconds = 0.25f;
        [SerializeField] float _baseIntensity01 = 0.5f;

        public string Id => _id;
        public ClinicFeedbackEventId EventId => _eventId;
        public ClinicFeedbackCategory Category => _category;
        public OperationRiskBand MinimumRiskBand => _minimumRiskBand;
        public OperationOutcomeType OutcomeType => _outcomeType;
        public string TechnicalAddress => _technicalAddress;
        public float DurationSeconds => _durationSeconds;
        public float BaseIntensity01 => _baseIntensity01;
    }
}
