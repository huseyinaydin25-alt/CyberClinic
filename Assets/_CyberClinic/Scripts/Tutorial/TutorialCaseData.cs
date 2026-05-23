using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialCase", menuName = "Cyber Clinic/Tutorial/Case")]
    public class TutorialCaseData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] int _fixedPatientSeed;
        [SerializeField] string _archetypeId;
        [SerializeField] string _requestTypeId;
        [SerializeField] string _hiddenConditionId;
        [SerializeField] string[] _allowedImplantIds;
        [SerializeField] TutorialSequenceData _sequence;

        public string Id => _id;
        public int FixedPatientSeed => _fixedPatientSeed;
        public string ArchetypeId => _archetypeId;
        public string RequestTypeId => _requestTypeId;
        public string HiddenConditionId => _hiddenConditionId;
        public string[] AllowedImplantIds => _allowedImplantIds;
        public TutorialSequenceData Sequence => _sequence;
    }
}
