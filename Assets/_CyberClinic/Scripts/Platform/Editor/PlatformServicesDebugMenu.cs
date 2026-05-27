#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Platform.Editor
{
    public static class PlatformServicesDebugMenu
    {
        [MenuItem("Cyber Clinic/Platform/Validate Mock Services")]
        public static void ValidateMockServices()
        {
            var entitlement = new MockEntitlementService();
            entitlement.SetEntitlement("test_premium_pack", true);
            entitlement.Refresh();

            var notifications = new MockNotificationService();
            notifications.Schedule(
                "test_return_reminder",
                "notification.return.title",
                "notification.return.body",
                30);
            notifications.Cancel("test_missing_id");

            var valid =
                entitlement.HasEntitlement("test_premium_pack") &&
                entitlement.RefreshCount == 1 &&
                notifications.ScheduledCount == 1 &&
                notifications.LastNotificationId == "test_return_reminder" &&
                notifications.LastTitleKey == "notification.return.title" &&
                notifications.LastBodyKey == "notification.return.body" &&
                notifications.LastDelayMinutes == 30;

            if (!valid)
            {
                Debug.LogWarning("PlatformServicesDebug failed");
                return;
            }

            notifications.Cancel("test_return_reminder");

            Debug.Log(
                "PlatformServicesDebug OK\n" +
                $"entitlementActive={entitlement.HasEntitlement("test_premium_pack")}\n" +
                $"refreshCount={entitlement.RefreshCount}\n" +
                $"lastNotificationId={notifications.LastNotificationId}\n" +
                $"lastTitleKey={notifications.LastTitleKey}\n" +
                $"lastBodyKey={notifications.LastBodyKey}\n" +
                $"lastDelayMinutes={notifications.LastDelayMinutes}\n" +
                $"remainingNotifications={notifications.ScheduledCount}");
        }
    }
}
#endif
