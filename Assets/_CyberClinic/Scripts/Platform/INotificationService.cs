namespace CyberClinic.Platform
{
    public interface INotificationService
    {
        void Schedule(string notificationId, string titleKey, string bodyKey, int delayMinutes);
        void Cancel(string notificationId);
    }
}
