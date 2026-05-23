using CyberClinic.Core;
using CyberClinic.Procedures;
using UnityEngine;

namespace CyberClinic.Visual
{
    [CreateAssetMenu(fileName = "ResultAnimation", menuName = "Cyber Clinic/Visual/Result Animation")]
    public class ResultAnimationData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] OperationOutcomeType _outcomeType;
        [SerializeField] string _prefabAddress;
        [SerializeField] float _duration = 1.5f;

        public string Id => _id;
        public OperationOutcomeType OutcomeType => _outcomeType;
        public string PrefabAddress => _prefabAddress;
        public float Duration => _duration;
    }
}
