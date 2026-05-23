using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Inputs used to derive deterministic seeds for patient generation and operations.
    /// Uses public fields for Unity serialization. OperationIndex is -1 when unused.
    /// </summary>
    [Serializable]
    public struct SeedContext : IEquatable<SeedContext>
    {
        public const int NoOperationIndex = -1;

        public int RunSeed;
        public int DayIndex;
        public int SlotIndex;
        public int OperationIndex;

        public SeedContext(int runSeed, int dayIndex, int slotIndex, int operationIndex = NoOperationIndex)
        {
            RunSeed = runSeed;
            DayIndex = dayIndex;
            SlotIndex = slotIndex;
            OperationIndex = operationIndex;
        }

        public bool HasOperationIndex => OperationIndex >= 0;

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
