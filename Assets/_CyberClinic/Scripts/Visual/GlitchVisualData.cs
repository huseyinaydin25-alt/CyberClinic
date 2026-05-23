using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Visual
{
    [CreateAssetMenu(fileName = "GlitchVisual", menuName = "Cyber Clinic/Visual/Glitch Effect")]
    public class GlitchVisualData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] string _shaderProfileId;
        [SerializeField] float _duration = 0.35f;
        [SerializeField] float _rgbSplitStrength = 0.02f;

        public string Id => _id;
        public string ShaderProfileId => _shaderProfileId;
        public float Duration => _duration;
        public float RgbSplitStrength => _rgbSplitStrength;
    }
}
