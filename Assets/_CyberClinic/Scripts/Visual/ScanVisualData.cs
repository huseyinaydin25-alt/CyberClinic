using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Visual
{
    [CreateAssetMenu(fileName = "ScanVisual", menuName = "Cyber Clinic/Visual/Scan Effect")]
    public class ScanVisualData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] string _prefabAddress;
        [SerializeField] float _beamDuration = 1.2f;
        [SerializeField] Color _beamColor = Color.cyan;

        public string Id => _id;
        public string PrefabAddress => _prefabAddress;
        public float BeamDuration => _beamDuration;
        public Color BeamColor => _beamColor;
    }
}
