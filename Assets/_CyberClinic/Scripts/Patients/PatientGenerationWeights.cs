using System;
using System.Collections.Generic;
using CyberClinic.Core;

namespace CyberClinic.Patients
{
    /// <summary>Deterministic weighted selection helpers for generation pools.</summary>
    public static class PatientGenerationWeights
    {
        public static T Pick<T>(CyberClinicRandom random, IReadOnlyList<T> items, Func<T, float> getWeight)
            where T : class
        {
            if (items == null || items.Count == 0)
            {
                return null;
            }

            if (items.Count == 1)
            {
                return items[0];
            }

            var total = 0f;
            for (var i = 0; i < items.Count; i++)
            {
                total += Math.Max(0f, getWeight(items[i]));
            }

            if (total <= 0f)
            {
                var index = random.NextInt(0, items.Count - 1);
                return items[index];
            }

            var roll = random.NextFloat(0f, total);
            var cumulative = 0f;
            for (var i = 0; i < items.Count; i++)
            {
                cumulative += Math.Max(0f, getWeight(items[i]));
                if (roll <= cumulative)
                {
                    return items[i];
                }
            }

            return items[items.Count - 1];
        }

        public static T PickWeightedDefinition<T>(CyberClinicRandom random, IReadOnlyList<T> items)
            where T : class, IWeightedDefinition =>
            Pick(random, items, item => item?.Weight ?? 0f);
    }
}
