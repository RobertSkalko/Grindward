using grindward.database;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AreaManager;

namespace grindward
{
    public static class ExtensionMethods
    {

        static List<AreaEnum> towns = new List<AreaEnum>() { AreaEnum.CierzoVillage, AreaEnum.Levant, AreaEnum.Monsoon, AreaEnum.Berg };
        static List<AreaEnum> outdoors = new List<AreaEnum>() { AreaEnum.CierzoOutside, AreaEnum.Abrassar, AreaEnum.HallowedMarsh, AreaEnum.Emercar };
        public static bool IsOutdoor(this Area area)
        {
            foreach (AreaEnum areaenum in outdoors)
            {
                Area current = AreaManager.Instance.GetArea(areaenum);

                if (current == area)
                {                  
                    return true;
                }
            }            

            return false;

        }
        public static bool IsTown(this Area area)
        {           
            foreach (AreaEnum areaenum in towns)
            {
                Area current = AreaManager.Instance.GetArea(areaenum);

                if (current == area)
                {
                    //Log.Debug("Is in town");
                    return true;
                }
            }
            //Log.Debug("Is not in town");

            return false;

        }

        public static Bag FindNearestBackpack(this Character character)
        {
            return character.Inventory.Equipment.LastOwnedBag;   
        }

        public static T RandomWeighted<T>(this IList<T> list) where T : IWeighted
        {
            return RandomUtils.WeightedRandom(list);
        }

        public static bool HasSameBuyAndSellValue(this Item item)
        {
            if (item.ItemID == ItemIDs.SILVER_COIN || item.ItemID == ItemIDs.GOLD_BAR)
            {
                return true;
            }

            return item.HasTag(TagSourceManager.Valuable);

        }
    }
}
