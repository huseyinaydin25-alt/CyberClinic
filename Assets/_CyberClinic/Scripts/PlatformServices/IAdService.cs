namespace CyberClinic.PlatformServices
{
    public interface IAdService
    {
        bool IsInitialized { get; }
        void Initialize();
        bool IsRewardedReady { get; }
        void ShowRewarded(string placementId);
    }
}
