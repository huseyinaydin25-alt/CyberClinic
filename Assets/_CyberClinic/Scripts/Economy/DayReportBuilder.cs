using System;

namespace CyberClinic.Economy
{
    public static class DayReportBuilder
    {
        public static DayReport Build(
            ClinicEconomyState startingState,
            EconomyDelta[] deltas,
            int acceptedPatients,
            int completedOperations,
            int failedOperations)
        {
            var start = startingState != null ? startingState.Clone() : new ClinicEconomyState();
            var safeDeltas = deltas ?? Array.Empty<EconomyDelta>();
            var end = EconomyCalculator.ApplyAll(start, safeDeltas);

            return new DayReport
            {
                DayIndex = start.DayIndex,
                StartingCredits = start.Credits,
                EndingCredits = end.Credits,
                StartingReputation = start.Reputation,
                EndingReputation = end.Reputation,
                AcceptedPatients = Math.Max(0, acceptedPatients),
                CompletedOperations = Math.Max(0, completedOperations),
                FailedOperations = Math.Max(0, failedOperations),
                Deltas = safeDeltas
            };
        }
    }
}
