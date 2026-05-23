using System;
using UnityEngine;

namespace CyberClinic.Localization
{
    /// <summary>
    /// Reference to player-facing text via localization key only.
    /// Do not store English or any display language in this type or in ScriptableObject string fields.
    /// Resolve at runtime through Unity Localization (Milestone 2+).
    /// </summary>
    [Serializable]
    public struct LocalizedTextRef : IEquatable<LocalizedTextRef>
    {
        [SerializeField] string _key;

        public LocalizationKey Key => new LocalizationKey(_key);

        public LocalizedTextRef(string key) => _key = key;

        public bool HasKey => Key.IsValid;

        public bool Equals(LocalizedTextRef other) => Key.Equals(other.Key);

        public override bool Equals(object obj) => obj is LocalizedTextRef other && Equals(other);

        public override int GetHashCode() => Key.GetHashCode();

        public static LocalizedTextRef FromKey(string key) => new LocalizedTextRef(key);
    }
}
