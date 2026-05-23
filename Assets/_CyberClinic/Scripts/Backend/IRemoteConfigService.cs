namespace CyberClinic.Backend
{
    public interface IRemoteConfigService
    {
        bool TryGetValue(string key, out string value);
        RemoteConfigSnapshot GetSnapshot();
    }
}
