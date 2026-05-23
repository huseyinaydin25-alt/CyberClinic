using System;

namespace CyberClinic.Core
{
    /// <summary>
    /// Deterministic pseudo-random generator. Does not use UnityEngine.Random.
    /// </summary>
    public sealed class CyberClinicRandom
    {
        readonly Random _random;

        public CyberClinicRandom(int seed)
        {
            _random = new Random(seed);
        }

        public static CyberClinicRandom FromSeedContext(SeedContext context) =>
            new CyberClinicRandom(context.ToPatientSeed());

        /// <summary>Float in [0, 1).</summary>
        public float NextFloat() => (float)_random.NextDouble();

        /// <summary>Float in [min, max].</summary>
        public float NextFloat(float min, float max) => min + (max - min) * NextFloat();

        /// <summary>Integer in [min, max] inclusive.</summary>
        public int NextInt(int min, int max) => _random.Next(min, max + 1);

        /// <summary>Combines multiple integers into a stable seed hash.</summary>
        public static int CombineSeed(params int[] values)
        {
            unchecked
            {
                var hash = 17;
                foreach (var value in values)
                {
                    hash = hash * 31 + value;
                }

                return hash;
            }
        }
    }
}
