using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Weighted reference to a definition used in generation pools and event tables.
    /// </summary>
    [Serializable]
    public struct WeightedEntry<T> where T : class, IWeightedDefinition
    {
        public T Definition;
        public float Weight;

        public WeightedEntry(T definition, float weight)
        {
            Definition = definition;
            Weight = weight;
        }

        public bool IsValid => Definition != null && Weight > 0f;
    }
}
