using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Cosmetics
{
    [CreateAssetMenu(fileName = "ClinicTierVisual", menuName = "Cyber Clinic/Cosmetics/Clinic Tier Visual")]
    public class ClinicTierVisualData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] ClinicTier _tier;
        [SerializeField] LocalizedTextRef _tierName;
        [SerializeField] float _equipmentBonus;
        [SerializeField] string _defaultThemeId;

        public string Id => _id;
        public ClinicTier Tier => _tier;
        public LocalizedTextRef TierName => _tierName;
        public float EquipmentBonus => _equipmentBonus;
        public string DefaultThemeId => _defaultThemeId;
    }
}
