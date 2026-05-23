using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Visual
{
    [CreateAssetMenu(fileName = "VisualFeedback", menuName = "Cyber Clinic/Visual/Feedback Mapping")]
    public class VisualFeedbackData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] VisualFeedbackType _feedbackType;
        [SerializeField] string _prefabAddress;
        [SerializeField] float _duration = 0.5f;
        [SerializeField] float _intensity = 1f;

        public string Id => _id;
        public VisualFeedbackType FeedbackType => _feedbackType;
        public string PrefabAddress => _prefabAddress;
        public float Duration => _duration;
        public float Intensity => _intensity;
    }
}
