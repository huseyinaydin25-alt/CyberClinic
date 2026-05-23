using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialSequence", menuName = "Cyber Clinic/Tutorial/Sequence")]
    public class TutorialSequenceData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _title;
        [SerializeField] TutorialStepData[] _steps;
        [SerializeField] bool _skippable = true;

        public string Id => _id;
        public LocalizedTextRef Title => _title;
        public TutorialStepData[] Steps => _steps;
        public bool Skippable => _skippable;
    }
}
