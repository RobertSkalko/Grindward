using grindward.database.gear_types;
using grindward.database.registers;
using grindward.utils;
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
        public abstract float GetItemTierReq();
        public abstract float GetMobTierReq();


        public abstract List<Weighted<Tier>> GetItemTierDropChances();

        public Tier GetRandomItemDropTier()
        {
            return RandomUtils.WeightedRandom(GetItemTierDropChances()).Get();
        }

        public static Tier TierGetTierOfMob(Character mob)
        {            
                float powerlvl = MobUtils.GetLootMulti(mob);

                Log.Debug(mob.Name + " Mob power lvl: " + powerlvl);

                Tier tier = Tiers.Instance.Weak;

                foreach (Tier t in Registry.Tiers.GetAll())
                {
                    if (t.GetTierNumber() > tier.GetTierNumber())
                    {
                        if (powerlvl >= t.GetItemTierReq())
                        {
                            tier = t;
                        }
                    }
            }            
            return tier;
        }

            public static Tier GetTierOfItem(Item item)
        {
            float powerlvl = GetPowerLevelEstimateOfItem(item);

            //Log.Debug(item.Name + " Item power lvl: " + powerlvl);

            Tier tier = Tiers.Instance.Weak;

            foreach (Tier t in Registry.Tiers.GetAll())
            {
                if (t.GetTierNumber() > tier.GetTierNumber())
                {
                    if (powerlvl >= t.GetItemTierReq())
                    {
                        tier = t;
                    }
                }
            }

            return tier;
        }

        public static float GetPowerLevelEstimateOfItem(Item item)
        {

            if (item == null)
            {
                return 0;
            }

            GearType type = ItemUtils.GetGearType(item);

            if (type == null)
            {
                return 0;
            }

            float highestPrice = type.GetAllItems().Max(x => x.Value);

            //Log.Debug("Highest value gear: " + highestPrice);

            float currentPrice = item.Value;

            float priceMulti = currentPrice / highestPrice;


            float highestDurability = type.GetAllItems().Where(x => !x.IsIndestructible).Max(x => x.MaxDurability);

            //Log.Debug("Highest durab gear: " + highestDurability);

            float currentDurability = item.MaxDurability;

            float durabilityMulti = currentDurability / highestDurability;

            if (item.IsIndestructible)
            {
                durabilityMulti = 1F;
            }


            return (durabilityMulti + priceMulti) / 2F;

          
        }

    }
}
