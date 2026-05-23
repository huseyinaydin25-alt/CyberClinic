using CyberClinic.Localization;

namespace CyberClinic.PlatformServices
{
    public interface INotificationService
    {
        bool HasPermission { get; }
        void RequestPermission();
        void ScheduleLocal(string notificationId, LocalizationKey titleKey, LocalizationKey bodyKey, int delaySeconds);
        void Cancel(string notificationId);
    }
}
