namespace CyberClinic.Backend
{
    public interface ICloudSaveService
    {
        bool Upload(CloudSavePayload payload);
        bool TryDownload(string playerId, out CloudSavePayload payload);
    }
}
