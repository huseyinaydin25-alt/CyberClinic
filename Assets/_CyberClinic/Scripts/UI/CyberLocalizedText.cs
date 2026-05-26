using CyberClinic.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.UI
{
    [RequireComponent(typeof(Text))]
    public sealed class CyberLocalizedText : MonoBehaviour
    {
        [SerializeField] LocalizedTextRef _text;

        public LocalizedTextRef Text => _text;

#if UNITY_EDITOR
        void OnValidate()
        {
            var label = GetComponent<Text>();
            if (label != null && _text.HasKey)
            {
                label.text = _text.Key.Value;
            }
        }
#endif
    }
}
