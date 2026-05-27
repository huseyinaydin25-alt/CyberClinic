using System;

namespace CyberClinic.Economy
{
    public static class EconomyCalculator
    {
        public static ClinicEconomyState Apply(ClinicEconomyState state, EconomyDelta delta)
        {
            if (state == null)
            {
                state = new ClinicEconomyState();
            }

            return new ClinicEconomyState
            {
                Credits = Math.Max(0, state.Credits + delta.CreditsDelta),
                Reputation = Math.Clamp(state.Reputation + delta.ReputationDelta, 0, 100),
                DayIndex = state.DayIndex
            };
        }

        public static ClinicEconomyState ApplyAll(ClinicEconomyState state, EconomyDelta[] deltas)
        {
            var current = state != null ? state.Clone() : new ClinicEconomyState();
            if (deltas == null)
            {
                return current;
            }

            for (var i = 0; i < deltas.Length; i++)
            {
                current = Apply(current, deltas[i]);
            }

            return current;
        }
    }
}
