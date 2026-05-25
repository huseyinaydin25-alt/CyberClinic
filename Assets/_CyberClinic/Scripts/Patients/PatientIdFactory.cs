using System;
using CyberClinic.Core;

namespace CyberClinic.Patients
{
    /// <summary>Deterministic patient instance identifiers (no Guid.NewGuid).</summary>
    public static class PatientIdFactory
    {
        public static Guid CreateInstanceId(SeedContext seedContext)
        {
            var patientSeed = seedContext.ToPatientSeed();
            var bytes = new byte[16];
            var seedBytes = BitConverter.GetBytes(patientSeed);
            var runBytes = BitConverter.GetBytes(seedContext.RunSeed);
            var dayBytes = BitConverter.GetBytes(seedContext.DayIndex);
            var slotBytes = BitConverter.GetBytes(seedContext.SlotIndex);
            var salt = BitConverter.GetBytes(CyberClinicRandom.CombineSeed(0x504154, patientSeed));

            Buffer.BlockCopy(seedBytes, 0, bytes, 0, 4);
            Buffer.BlockCopy(runBytes, 0, bytes, 4, 4);
            Buffer.BlockCopy(dayBytes, 0, bytes, 8, 2);
            Buffer.BlockCopy(slotBytes, 0, bytes, 10, 2);
            Buffer.BlockCopy(salt, 0, bytes, 12, 4);

            return new Guid(bytes);
        }
    }
}
