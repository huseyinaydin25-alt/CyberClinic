using System.Collections.Generic;

namespace CyberClinic.Platform
{
    public sealed class MockEntitlementService : IEntitlementService
    {
        readonly HashSet<string> _ids = new HashSet<string>();

        public int RefreshCount { get; private set; }

        public void SetEntitlement(string entitlementId, bool active)
        {
            if (string.IsNullOrWhiteSpace(entitlementId))
            {
                return;
            }

            if (active)
            {
                _ids.Add(entitlementId);
            }
            else
            {
                _ids.Remove(entitlementId);
            }
        }

        public bool HasEntitlement(string entitlementId)
        {
            return !string.IsNullOrWhiteSpace(entitlementId) && _ids.Contains(entitlementId);
        }

        public void Refresh()
        {
            RefreshCount++;
        }
    }
}
