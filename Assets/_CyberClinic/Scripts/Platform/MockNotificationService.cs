using System.Collections.Generic;

namespace CyberClinic.Platform
{
    public sealed class MockNotificationService : INotificationService
    {
        readonly HashSet<string> _scheduled = new HashSet<string>();

        public int ScheduledCount => _scheduled.Count;
        public string LastNotificationId { get; private set; }
        public string LastTitleKey { get; private set; }
        public string LastBodyKey { get; private set; }
        public int LastDelayMinutes { get; private set; }

        public void Schedule(string notificationId, string titleKey, string bodyKey, int delayMinutes)
        {
            if (string.IsNullOrWhiteSpace(notificationId))
            {
                return;
            }

            _scheduled.Add(notificationId);
            LastNotificationId = notificationId;
            LastTitleKey = titleKey ?? string.Empty;
            LastBodyKey = bodyKey ?? string.Empty;
            LastDelayMinutes = delayMinutes < 0 ? 0 : delayMinutes;
        }

        public void Cancel(string notificationId)
        {
            if (!string.IsNullOrWhiteSpace(notificationId))
            {
                _scheduled.Remove(notificationId);
            }
        }
    }
}
