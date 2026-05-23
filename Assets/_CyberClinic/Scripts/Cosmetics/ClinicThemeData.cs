using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Cosmetics
{
    [CreateAssetMenu(fileName = "ClinicTheme", menuName = "Cyber Clinic/Cosmetics/Clinic Theme")]
    public class ClinicThemeData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] ClinicTier _requiredTier;
        [SerializeField] string _backgroundAddress;
        [SerializeField] string _lightingProfileId;

        public string Id => _id;
        public LocalizedTextRef Name => _name;
        public ClinicTier RequiredTier => _requiredTier;
        public string BackgroundAddress => _backgroundAddress;
        public string LightingProfileId => _lightingProfileId;
    }
}
