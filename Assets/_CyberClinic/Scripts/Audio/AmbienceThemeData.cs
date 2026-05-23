using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Audio
{
    [CreateAssetMenu(fileName = "AmbienceTheme", menuName = "Cyber Clinic/Audio/Ambience Theme")]
    public class AmbienceThemeData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] string _roomToneAddress;
        [SerializeField] string _rainLoopAddress;
        [SerializeField] string _cityBedAddress;
        [SerializeField] float _baseVolume = 0.6f;

        public string Id => _id;
        public string RoomToneAddress => _roomToneAddress;
        public string RainLoopAddress => _rainLoopAddress;
        public string CityBedAddress => _cityBedAddress;
        public float BaseVolume => _baseVolume;
    }
}
