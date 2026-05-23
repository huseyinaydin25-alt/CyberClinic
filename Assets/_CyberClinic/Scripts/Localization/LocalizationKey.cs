using System;

namespace CyberClinic.Localization
{
    /// <summary>
    /// Stable localization table entry id. Player-facing copy lives in String Tables, not in code.
    /// Uses a public field for Unity serialization.
    /// </summary>
    [Serializable]
    public struct LocalizationKey : IEquatable<LocalizationKey>
    {
        public string Value;

        public LocalizationKey(string value) => Value = value ?? string.Empty;

        public bool IsEmpty => string.IsNullOrWhiteSpace(Value);

        public bool IsValid => !IsEmpty;

        public bool Equals(LocalizationKey other) =>
            string.Equals(Value, other.Value, StringComparison.Ordinal);

        public override bool Equals(object obj) => obj is LocalizationKey other && Equals(other);

        public override int GetHashCode() =>
            Value != null ? Value.GetHashCode(StringComparison.Ordinal) : 0;

        public override string ToString() => Value ?? string.Empty;

        public static implicit operator LocalizationKey(string key) => new LocalizationKey(key);
    }
}
