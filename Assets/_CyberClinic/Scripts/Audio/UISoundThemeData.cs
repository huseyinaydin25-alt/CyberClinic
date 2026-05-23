using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Audio
{
    [CreateAssetMenu(fileName = "UISoundTheme", menuName = "Cyber Clinic/Audio/UI Sound Theme")]
    public class UISoundThemeData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] string _clickAddress;
        [SerializeField] string _panelOpenAddress;
        [SerializeField] string _panelCloseAddress;
        [SerializeField] string _warningTickAddress;

        public string Id => _id;
        public string ClickAddress => _clickAddress;
        public string PanelOpenAddress => _panelOpenAddress;
        public string PanelCloseAddress => _panelCloseAddress;
        public string WarningTickAddress => _warningTickAddress;
    }
}
