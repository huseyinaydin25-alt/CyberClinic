using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Cosmetics
{
    [CreateAssetMenu(fileName = "VisualPack", menuName = "Cyber Clinic/Cosmetics/Visual Pack")]
    public class VisualPackData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] string[] _prefabAddresses;
        [SerializeField] string[] _shaderProfileIds;

        public string Id => _id;
        public string[] PrefabAddresses => _prefabAddresses;
        public string[] ShaderProfileIds => _shaderProfileIds;
    }
}
