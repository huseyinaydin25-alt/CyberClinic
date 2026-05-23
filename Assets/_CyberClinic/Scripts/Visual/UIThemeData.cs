using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Visual
{
    [CreateAssetMenu(fileName = "UITheme", menuName = "Cyber Clinic/Visual/UI Theme")]
    public class UIThemeData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _displayName;
        [SerializeField] Color _primaryAccent = Color.cyan;
        [SerializeField] Color _warningAccent = Color.red;
        [SerializeField] string _panelStyleAddress;

        public string Id => _id;
        public LocalizedTextRef DisplayName => _displayName;
        public Color PrimaryAccent => _primaryAccent;
        public Color WarningAccent => _warningAccent;
        public string PanelStyleAddress => _panelStyleAddress;
    }
}
