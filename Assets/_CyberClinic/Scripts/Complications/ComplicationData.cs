using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Complications
{
    [CreateAssetMenu(fileName = "Complication", menuName = "Cyber Clinic/Complications/Complication")]
    public class ComplicationData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] ComplicationSeverity _severity;
        [SerializeField] float _reputationPenalty;
        [SerializeField] int _moneyPenalty;

        public string Id => _id;
        public float Weight => _weight;
        public LocalizedTextRef Name => _name;
        public LocalizedTextRef Description => _description;
        public ComplicationSeverity Severity => _severity;
        public float ReputationPenalty => _reputationPenalty;
        public int MoneyPenalty => _moneyPenalty;
    }
}
