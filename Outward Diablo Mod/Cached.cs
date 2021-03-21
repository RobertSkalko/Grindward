using grindward.database;
using grindward.database.gear_types;
using grindward.database.registers;
using grindward.database.tiers;
using grindward.database.tiers.bases;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class Cached
    {
        // add manual stuff here
        public Cached()
        {
            ITEM_TIER = new Dictionary<int, Tier>();
            ITEM_TIER.Add(5100080, new Endgame()); // lanern of souls

        }

        public static Cached Instance;

        public Dictionary<int, bool> ITEM_IS_GEAR = new Dictionary<int, bool>();
        public Dictionary<int, GearType> ITEM_GEAR_TYPES = new Dictionary<int, GearType>();
        public Dictionary<int, float> ITEM_POWER_LVL = new Dictionary<int, float>();
        public Dictionary<int, Tier> ITEM_TIER = new Dictionary<int, Tier>();


        public static Item GetDefaultItemPrefab(Item item)
        {
            return CustomItems.GetOriginalItemPrefab(item.ItemID);

        }
    }
}
