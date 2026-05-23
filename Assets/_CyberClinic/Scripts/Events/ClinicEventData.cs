using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Events
{
    [CreateAssetMenu(fileName = "ClinicEvent", menuName = "Cyber Clinic/Events/Clinic Event")]
    public class ClinicEventData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] ClinicEventType _eventType;
        [SerializeField] LocalizedTextRef _title;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] float _reputationModifier;
        [SerializeField] float _moneyModifier;

        public string Id => _id;
        public float Weight => _weight;
        public ClinicEventType EventType => _eventType;
        public LocalizedTextRef Title => _title;
        public LocalizedTextRef Description => _description;
        public float ReputationModifier => _reputationModifier;
        public float MoneyModifier => _moneyModifier;
    }
}
