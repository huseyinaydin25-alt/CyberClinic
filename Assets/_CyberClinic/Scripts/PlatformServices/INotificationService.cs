namespace CyberClinic.PlatformServices
{
    public interface INotificationService
    {
        bool HasPermission { get; }
        void RequestPermission();
        void ScheduleLocal(string notificationId, string titleKey, string bodyKey, int delaySeconds);
        void Cancel(string notificationId);
    }
}
