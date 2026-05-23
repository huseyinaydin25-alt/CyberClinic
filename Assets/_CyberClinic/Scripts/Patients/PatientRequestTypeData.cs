using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Patients
{
    [CreateAssetMenu(fileName = "PatientRequestType", menuName = "Cyber Clinic/Patients/Request Type")]
    public class PatientRequestTypeData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] BodySlot _targetSlot;
        [SerializeField] string _linkedProcedureId;

        public string Id => _id;
        public float Weight => _weight;
        public LocalizedTextRef Description => _description;
        public BodySlot TargetSlot => _targetSlot;
        public string LinkedProcedureId => _linkedProcedureId;
    }
}
