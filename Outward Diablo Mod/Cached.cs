using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class Cached
    {
        public static Cached Instance;

         public Dictionary<int, bool> ITEM_IS_GEAR = new Dictionary<int, bool>();
         public Dictionary<int, float> ITEM_POWER_LVL = new Dictionary<int, float>();

       
        public static Item GetDefaultItemPrefab(Item item)
        {
            return CustomItems.RPM_ITEM_PREFABS[item.ItemIDString];

        }
    }
}
