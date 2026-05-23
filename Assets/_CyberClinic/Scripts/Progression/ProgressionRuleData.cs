using CyberClinic.Core;
using CyberClinic.Cosmetics;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Progression
{
    [CreateAssetMenu(fileName = "ProgressionRule", menuName = "Cyber Clinic/Progression/Rule")]
    public class ProgressionRuleData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] ClinicTier _targetTier;
        [SerializeField] float _reputationRequired;
        [SerializeField] int _moneyRequired;
        [SerializeField] LocalizedTextRef _unlockMessage;
        [SerializeField] float _clinicSkillBonusAdd;
        [SerializeField] float _equipmentBonusAdd;

        public string Id => _id;
        public ClinicTier TargetTier => _targetTier;
        public float ReputationRequired => _reputationRequired;
        public int MoneyRequired => _moneyRequired;
        public LocalizedTextRef UnlockMessage => _unlockMessage;
        public float ClinicSkillBonusAdd => _clinicSkillBonusAdd;
        public float EquipmentBonusAdd => _equipmentBonusAdd;
    }
}
