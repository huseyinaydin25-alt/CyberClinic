using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Cosmetics
{
    [CreateAssetMenu(fileName = "Cosmetic", menuName = "Cyber Clinic/Cosmetics/Cosmetic")]
    public class CosmeticData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] CosmeticCategory _category;
        [SerializeField] CosmeticRarity _rarity;
        [SerializeField] CosmeticPurchaseType _purchaseType;
        [SerializeField] CosmeticFunctionalEffectType _functionalEffect;
        [SerializeField] string _visualPackId;
        [SerializeField] int _cost;

        public string Id => _id;
        public LocalizedTextRef Name => _name;
        public LocalizedTextRef Description => _description;
        public CosmeticCategory Category => _category;
        public CosmeticRarity Rarity => _rarity;
        public CosmeticPurchaseType PurchaseType => _purchaseType;
        public CosmeticFunctionalEffectType FunctionalEffect => _functionalEffect;
        public string VisualPackId => _visualPackId;
        public int Cost => _cost;
    }
}
