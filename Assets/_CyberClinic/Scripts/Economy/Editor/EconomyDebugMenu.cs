#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Economy.Editor
{
    public static class EconomyDebugMenu
    {
        [MenuItem("Cyber Clinic/Economy/Run Day Flow Debug")]
        public static void RunDayFlowDebug()
        {
            var start = new ClinicRuntimeState
            {
                Economy = new ClinicEconomyState
                {
                    Credits = 500,
                    Reputation = 40,
                    DayIndex = 4
                },
                CurrentDayIndex = 4,
                DayActive = false
            };

            var started = DayFlowController.StartDay(start, 4).State;
            var afterPatientA = DayFlowController.RecordPatientAccepted(started);
            var afterPatientB = DayFlowController.RecordPatientAccepted(afterPatientA);
            var afterCompleted = DayFlowController.RecordOperationCompleted(afterPatientB);
            var afterFailed = DayFlowController.RecordOperationFailed(afterCompleted);

            var deltas = new[]
            {
                new EconomyDelta(180, 6, "debug.operation_success"),
                new EconomyDelta(-45, 0, "debug.supply_cost"),
                new EconomyDelta(0, -3, "debug.patient_unstable")
            };

            var ended = DayFlowController.EndDay(afterFailed, deltas);
            var report = ended.Report;
            var endState = ended.State;

            var deterministic =
                report != null &&
                report.DayIndex == 4 &&
                report.StartingCredits == 500 &&
                report.EndingCredits == 635 &&
                report.StartingReputation == 40 &&
                report.EndingReputation == 43 &&
                report.AcceptedPatients == 2 &&
                report.CompletedOperations == 1 &&
                report.FailedOperations == 1 &&
                report.Deltas.Length == 3 &&
                endState != null &&
                endState.DayActive == false &&
                endState.CurrentDayIndex == 5 &&
                endState.Economy.Credits == 635 &&
                endState.Economy.Reputation == 43;

            if (!deterministic)
            {
                Debug.LogWarning("EconomyDebug failed");
                return;
            }

            Debug.Log(
                "EconomyDebug OK\n" +
                $"dayIndex={report.DayIndex}\n" +
                $"startingCredits={report.StartingCredits}\n" +
                $"endingCredits={report.EndingCredits}\n" +
                $"startingReputation={report.StartingReputation}\n" +
                $"endingReputation={report.EndingReputation}\n" +
                $"acceptedPatients={report.AcceptedPatients}\n" +
                $"completedOperations={report.CompletedOperations}\n" +
                $"failedOperations={report.FailedOperations}\n" +
                $"deltaCount={report.Deltas.Length}\n" +
                $"dayActive={endState.DayActive}\n" +
                $"nextDayIndex={endState.CurrentDayIndex}");
        }
    }
}
#endif
