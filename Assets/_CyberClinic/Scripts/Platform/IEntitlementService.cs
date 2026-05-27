namespace CyberClinic.Platform
{
    public interface IEntitlementService
    {
        bool HasEntitlement(string entitlementId);
        void Refresh();
    }
}
