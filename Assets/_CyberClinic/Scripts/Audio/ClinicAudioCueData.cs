using CyberClinic.Core;
using CyberClinic.Procedures;
using UnityEngine;

namespace CyberClinic.Audio
{
    [CreateAssetMenu(fileName = "ClinicAudioCue", menuName = "Cyber Clinic/Audio/Cue")]
    public class ClinicAudioCueData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] ClinicAudioEventId _eventId;
        [SerializeField] ClinicAudioCategory _category;
        [SerializeField] OperationRiskBand _minimumRiskBand;
        [SerializeField] OperationOutcomeType _outcomeType;
        [SerializeField] string _clipAddress;
        [SerializeField] float _volume01 = 0.8f;
        [SerializeField] float _pitchMin = 1f;
        [SerializeField] float _pitchMax = 1f;
        [SerializeField] float _cooldownSeconds = 0.05f;

        public string Id => _id;
        public ClinicAudioEventId EventId => _eventId;
        public ClinicAudioCategory Category => _category;
        public OperationRiskBand MinimumRiskBand => _minimumRiskBand;
        public OperationOutcomeType OutcomeType => _outcomeType;
        public string ClipAddress => _clipAddress;
        public float Volume01 => _volume01;
        public float PitchMin => _pitchMin;
        public float PitchMax => _pitchMax;
        public float CooldownSeconds => _cooldownSeconds;
    }
}
