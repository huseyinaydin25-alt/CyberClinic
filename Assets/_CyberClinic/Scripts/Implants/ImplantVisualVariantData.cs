using CyberClinic.Core;
using CyberClinic.Localization;
using CyberClinic.Patients;
using UnityEngine;

namespace CyberClinic.Implants
{
    [CreateAssetMenu(fileName = "ImplantVisualVariant", menuName = "Cyber Clinic/Implants/Visual Variant")]
    public class ImplantVisualVariantData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _label;
        [SerializeField] string _implantId;
        [SerializeField] BodySlot _targetSlot;
        [SerializeField] ImplantTierType _tier;
        [SerializeField] ImplantQualityType _quality;
        [SerializeField] string _spriteAddress;
        [SerializeField] string _vfxProfileId;
        [SerializeField] Color _accentTint = Color.white;

        public string Id => _id;
        public LocalizedTextRef Label => _label;
        public string ImplantId => _implantId;
        public BodySlot TargetSlot => _targetSlot;
        public ImplantTierType Tier => _tier;
        public ImplantQualityType Quality => _quality;
        public string SpriteAddress => _spriteAddress;
        public string VfxProfileId => _vfxProfileId;
        public Color AccentTint => _accentTint;
    }
}
