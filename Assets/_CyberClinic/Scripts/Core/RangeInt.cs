using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Inclusive integer range for counts, day indices, and discrete rolls.
    /// </summary>
    [Serializable]
    public struct RangeInt : IEquatable<RangeInt>
    {
        public int Min;
        public int Max;

        public RangeInt(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public bool Contains(int value) => value >= Min && value <= Max;

        public bool Equals(RangeInt other) => Min == other.Min && Max == other.Max;

        public override bool Equals(object obj) => obj is RangeInt other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Min, Max);
    }
}
