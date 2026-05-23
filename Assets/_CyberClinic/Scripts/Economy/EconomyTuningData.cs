using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Economy
{
    [CreateAssetMenu(fileName = "EconomyTuning", menuName = "Cyber Clinic/Economy/Tuning")]
    public class EconomyTuningData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] int _startingMoney = 500;
        [SerializeField] float _startingReputation = 0.5f;
        [SerializeField] int _basicScanCost = 25;
        [SerializeField] int _deepScanCost = 75;
        [SerializeField] float _operationVarianceHalfRange = 0.05f;

        public string Id => _id;
        public int StartingMoney => _startingMoney;
        public float StartingReputation => _startingReputation;
        public int BasicScanCost => _basicScanCost;
        public int DeepScanCost => _deepScanCost;
        public float OperationVarianceHalfRange => _operationVarianceHalfRange;
    }
}
