using System;

namespace CyberClinic.Economy
{
    public static class DayFlowController
    {
        public static DayFlowResult StartDay(ClinicRuntimeState state, int dayIndex)
        {
            var next = state != null ? state.Clone() : new ClinicRuntimeState();
            next.DayActive = true;
            next.CurrentDayIndex = Math.Max(0, dayIndex);
            next.AcceptedPatientsToday = 0;
            next.CompletedOperationsToday = 0;
            next.FailedOperationsToday = 0;
            next.Economy.DayIndex = next.CurrentDayIndex;

            return new DayFlowResult
            {
                State = next,
                Report = null,
                TechnicalMessage = "day.started"
            };
        }

        public static ClinicRuntimeState RecordPatientAccepted(ClinicRuntimeState state)
        {
            var next = state != null ? state.Clone() : new ClinicRuntimeState();
            next.AcceptedPatientsToday = Math.Max(0, next.AcceptedPatientsToday + 1);
            return next;
        }

        public static ClinicRuntimeState RecordOperationCompleted(ClinicRuntimeState state)
        {
            var next = state != null ? state.Clone() : new ClinicRuntimeState();
            next.CompletedOperationsToday = Math.Max(0, next.CompletedOperationsToday + 1);
            return next;
        }

        public static ClinicRuntimeState RecordOperationFailed(ClinicRuntimeState state)
        {
            var next = state != null ? state.Clone() : new ClinicRuntimeState();
            next.FailedOperationsToday = Math.Max(0, next.FailedOperationsToday + 1);
            return next;
        }

        public static DayFlowResult EndDay(ClinicRuntimeState state, EconomyDelta[] deltas)
        {
            var current = state != null ? state.Clone() : new ClinicRuntimeState();
            var startEconomy = current.Economy != null ? current.Economy.Clone() : new ClinicEconomyState();
            var report = DayReportBuilder.Build(
                startEconomy,
                deltas ?? Array.Empty<EconomyDelta>(),
                current.AcceptedPatientsToday,
                current.CompletedOperationsToday,
                current.FailedOperationsToday);

            current.Economy.Credits = report.EndingCredits;
            current.Economy.Reputation = report.EndingReputation;
            current.Economy.DayIndex = report.DayIndex + 1;
            current.CurrentDayIndex = current.Economy.DayIndex;
            current.DayActive = false;
            current.AcceptedPatientsToday = 0;
            current.CompletedOperationsToday = 0;
            current.FailedOperationsToday = 0;

            return new DayFlowResult
            {
                State = current,
                Report = report,
                TechnicalMessage = "day.ended"
            };
        }
    }
}
