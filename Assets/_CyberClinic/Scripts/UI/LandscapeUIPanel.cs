using UnityEngine;

namespace CyberClinic.UI
{
    public sealed class LandscapeUIPanel : MonoBehaviour
    {
        [SerializeField] LandscapeUIScreenId _panelId;
        [SerializeField] string _technicalId;

        public LandscapeUIScreenId PanelId => _panelId;
        public string TechnicalId => _technicalId;
    }
}
