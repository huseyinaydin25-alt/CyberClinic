using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Normalized value in the closed interval [0, 1] (success chance, resistance, pressure).
    /// </summary>
    [Serializable]
    public readonly struct Percentage01 : IEquatable<Percentage01>
    {
        public float Value { get; }

        public Percentage01(float value)
        {
            Value = Math.Clamp(value, 0f, 1f);
        }

        public static Percentage01 Zero => new Percentage01(0f);
        public static Percentage01 One => new Percentage01(1f);

        public static Percentage01 From01(float value) => new Percentage01(value);

        public bool Equals(Percentage01 other) => Value.Equals(other.Value);

        public override bool Equals(object obj) => obj is Percentage01 other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString("F3");
    }
}
