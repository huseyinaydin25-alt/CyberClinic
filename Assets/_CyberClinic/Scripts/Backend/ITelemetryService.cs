namespace CyberClinic.Backend
{
    public interface ITelemetryService
    {
        void TrackEvent(string eventName, string payloadJson = null);
    }
}
