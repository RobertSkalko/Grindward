using grindward.database.registers;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.tiers.bases
{
    public abstract class Tier : RegistryEntry
    {
        public abstract string GetId();

        public abstract int GetTierNumber();
        public abstract float GetTierReq();

        public static Tier GetTierOfItem(Item item)
        {
            float powerlvl = GetPowerLevelEstimateOfItem(item);

            Tier tier = Tiers.Instance.Weak;

            foreach (Tier t in Registry.Tiers.GetAll())
            {
                if (t.GetTierNumber() > tier.GetTierNumber())
                {
                    if (powerlvl >= t.GetTierReq())
                    {
                        tier = t;
                    }
                }
            }

            return tier;
        }

        public static float GetPowerLevelEstimateOfItem(Item item)
        {

            float highestPrice = CustomItems.RPM_ITEM_PREFABS.Values.Where(x => ItemUtils.IsGear(x)).Max(x => x.Value);

            float currentPrice = item.Value;

            float priceMulti = currentPrice / highestPrice;


            float highestDurability = CustomItems.RPM_ITEM_PREFABS.Values.Where(x => ItemUtils.IsGear(x) && !x.IsIndestructible).Max(x => x.MaxDurability);

            float currentDurability = item.MaxDurability;

            float durabilityMulti = currentDurability / highestDurability;

            if (item.IsIndestructible)
            {
                durabilityMulti = 1F;
            }


            List<float> multis = new List<float>();

            multis.Add(durabilityMulti);
            multis.Add(priceMulti);

            return multis.Average();
        }

    }
}
