using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Inputs used to derive deterministic seeds for patient generation and operations.
    /// </summary>
    [Serializable]
    public readonly struct SeedContext : IEquatable<SeedContext>
    {
        public int RunSeed { get; }
        public int DayIndex { get; }
        public int SlotIndex { get; }
        public int? OperationIndex { get; }

        public SeedContext(int runSeed, int dayIndex, int slotIndex, int? operationIndex = null)
        {
            RunSeed = runSeed;
            DayIndex = dayIndex;
            SlotIndex = slotIndex;
            OperationIndex = operationIndex;
        }

        /// <summary>Seed for procedural patient generation at this queue slot.</summary>
        public int ToPatientSeed() => CyberClinicRandom.CombineSeed(RunSeed, DayIndex, SlotIndex);

        /// <summary>Seed for a committed operation (requires operation index).</summary>
        public int ToOperationSeed(int operationIndex)
        {
            return CyberClinicRandom.CombineSeed(RunSeed, DayIndex, SlotIndex, operationIndex);
        }

        public bool Equals(SeedContext other) =>
            RunSeed == other.RunSeed &&
            DayIndex == other.DayIndex &&
            SlotIndex == other.SlotIndex &&
            OperationIndex == other.OperationIndex;

        public override bool Equals(object obj) => obj is SeedContext other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(RunSeed, DayIndex, SlotIndex, OperationIndex);
    }
}
