using CyberClinic.Core;
using CyberClinic.Localization;
using CyberClinic.Patients;
using UnityEngine;

namespace CyberClinic.Implants
{
    [CreateAssetMenu(fileName = "Implant", menuName = "Cyber Clinic/Implants/Implant")]
    public class ImplantData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] BodySlot _targetSlot;
        [SerializeField] ImplantTierType _tier;
        [SerializeField] ImplantLegalityType _legality;
        [SerializeField] ImplantQualityType _quality;
        [SerializeField] float _cyberToxLoad;
        [SerializeField] float _neuralLoad;
        [SerializeField] int _baseCost;
        [SerializeField] float _compatibilityBonus;

        public string Id => _id;
        public LocalizedTextRef Name => _name;
        public LocalizedTextRef Description => _description;
        public BodySlot TargetSlot => _targetSlot;
        public ImplantTierType Tier => _tier;
        public ImplantLegalityType Legality => _legality;
        public ImplantQualityType Quality => _quality;
        public float CyberToxLoad => _cyberToxLoad;
        public float NeuralLoad => _neuralLoad;
        public int BaseCost => _baseCost;
        public float CompatibilityBonus => _compatibilityBonus;
    }
}
