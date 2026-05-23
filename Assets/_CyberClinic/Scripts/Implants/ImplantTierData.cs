using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Implants
{
    [CreateAssetMenu(fileName = "ImplantTier", menuName = "Cyber Clinic/Implants/Tier")]
    public class ImplantTierData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] ImplantTierType _tierType;
        [SerializeField] LocalizedTextRef _displayName;
        [SerializeField] float _costMultiplier = 1f;
        [SerializeField] float _riskMultiplier = 1f;
        [SerializeField] float _illegalRiskAdd;

        public string Id => _id;
        public ImplantTierType TierType => _tierType;
        public LocalizedTextRef DisplayName => _displayName;
        public float CostMultiplier => _costMultiplier;
        public float RiskMultiplier => _riskMultiplier;
        public float IllegalRiskAdd => _illegalRiskAdd;
    }
}
