using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Inclusive floating-point range for tuning and procedural rolls.
    /// </summary>
    [Serializable]
    public struct RangeFloat : IEquatable<RangeFloat>
    {
        public float Min;
        public float Max;

        public RangeFloat(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public float Lerp(float t) => Min + (Max - Min) * t;

        public float Clamp(float value) => Math.Clamp(value, Min, Max);

        public bool Equals(RangeFloat other) => Min.Equals(other.Min) && Max.Equals(other.Max);

        public override bool Equals(object obj) => obj is RangeFloat other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Min, Max);
    }
}
