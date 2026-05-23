using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Audio
{
    [CreateAssetMenu(fileName = "AudioFeedback", menuName = "Cyber Clinic/Audio/Feedback Mapping")]
    public class AudioFeedbackData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] AudioFeedbackType _feedbackType;
        [SerializeField] string _clipAddress;
        [SerializeField] float _volume = 1f;
        [SerializeField] float _pitchVariance;

        public string Id => _id;
        public AudioFeedbackType FeedbackType => _feedbackType;
        public string ClipAddress => _clipAddress;
        public float Volume => _volume;
        public float PitchVariance => _pitchVariance;
    }
}
