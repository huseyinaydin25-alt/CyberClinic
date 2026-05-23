namespace CyberClinic.PlatformServices
{
    /// <summary>IAP and entitlements (RevenueCat adapter in Milestone 10.5). No SDK references here.</summary>
    public interface IRevenueService
    {
        bool IsInitialized { get; }
        void Initialize();
        bool HasEntitlement(string entitlementId);
        void RestorePurchases();
    }
}
