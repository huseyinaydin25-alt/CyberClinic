using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Events
{
    [CreateAssetMenu(fileName = "SeasonalEvent", menuName = "Cyber Clinic/Events/Seasonal Event")]
    public class SeasonalEventData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] SeasonalEventType _eventType;
        [SerializeField] LocalizedTextRef _title;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] string _themePackId;
        [SerializeField] int _startDayOfYear;
        [SerializeField] int _durationDays = 7;

        public string Id => _id;
        public SeasonalEventType EventType => _eventType;
        public LocalizedTextRef Title => _title;
        public LocalizedTextRef Description => _description;
        public string ThemePackId => _themePackId;
        public int StartDayOfYear => _startDayOfYear;
        public int DurationDays => _durationDays;
    }
}
