namespace CyberClinic.Platform
{
    public interface IAdService
    {
        bool IsReady(string placementId);
        void Show(string placementId);
    }
}
