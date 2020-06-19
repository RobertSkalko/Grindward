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
    public abstract class Tier : RegistryEntry , IWeighted
    {
        public static int MAX_RANDOM_PERCENT = 80;

        public abstract string GetId();

        public abstract string GetItemTierName();

        public abstract int GetTierNumber();
        public abstract float GetItemTierReq();
        public abstract float GetMobTierReq();

        public abstract MinMax GetRandomStatsPercents();

        public Tier GetHigherTier()
        {
            if (Registry.Tiers.GetAll().Max(x=> x.GetTierNumber()) == this.GetTierNumber())
            {
                return this;
            }
            else
            {
                return Registry.Tiers.GetAll().Where(x => x.GetTierNumber() == GetTierNumber() + 1).First();
            }

        }

        public abstract List<Weighted<Tier>> GetItemTierDropChances();

        public Tier GetRandomItemDropTier()
        {
            return RandomUtils.WeightedRandom(GetItemTierDropChances()).Get();
        }

        public static Tier TierGetTierOfMob(Character mob)
        {            
                float powerlvl = MobUtils.GetLootMulti(mob);

             
                Tier tier = Tiers.Instance.Weak;

                foreach (Tier t in Registry.Tiers.GetAll())
                {
                    if (t.GetTierNumber() > tier.GetTierNumber())
                    {
                        if (powerlvl >= t.GetMobTierReq())
                        {
                            tier = t;
                        }
                    }
            }

            Log.Debug(mob.Name + " Mob power lvl: " + powerlvl + " tier: " + tier.GetId());


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

            if (Cached.Instance.ITEM_POWER_LVL.ContainsKey(item.ItemID)){
                return Cached.Instance.ITEM_POWER_LVL[item.ItemID];
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
                durabilityMulti = 1F + 0.2F; // indestructable items are usually super rare op ones
            }

            float result= (durabilityMulti + priceMulti) / 2F;

            Cached.Instance.ITEM_POWER_LVL.Add(item.ItemID, result);

            return result;
                      
        }

        public abstract int GetWeight();
    }
}
