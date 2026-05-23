using System;
using System.Collections.Generic;

namespace CyberClinic.Cosmetics
{
    [Serializable]
    public class CosmeticOwnershipState
    {
        public List<string> OwnedCosmeticIds = new List<string>();
        public List<string> EquippedCosmeticIds = new List<string>();
    }
}
