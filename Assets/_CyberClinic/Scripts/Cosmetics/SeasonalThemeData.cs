using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Cosmetics
{
    [CreateAssetMenu(fileName = "SeasonalTheme", menuName = "Cyber Clinic/Cosmetics/Seasonal Theme")]
    public class SeasonalThemeData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] string _visualPackId;
        [SerializeField] string _ambienceThemeId;
        [SerializeField] string _linkedSeasonalEventId;

        public string Id => _id;
        public LocalizedTextRef Name => _name;
        public string VisualPackId => _visualPackId;
        public string AmbienceThemeId => _ambienceThemeId;
        public string LinkedSeasonalEventId => _linkedSeasonalEventId;
    }
}
