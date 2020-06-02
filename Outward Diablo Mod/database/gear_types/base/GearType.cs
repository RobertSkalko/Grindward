using grindward.database;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward.database.gear_types
{
    public abstract class GearType : RegistryEntry , IWeighted
    {
      
        public abstract bool isType(Item item);
        public abstract string GetId();
        public abstract int GetWeight();

        public List<Item> GetAllItems()
        {
            List<Item> list= CustomItems.RPM_ITEM_PREFABS.Values.Where(x => ItemUtils.IsGear(x) && isType(x)).ToList();

            if (list.Count  < 1)
            {
                UnityEngine.Debug.Log("There are 0 items of type: " + GetId() + ". This shouldn't be possible!!");
            }

            return list;
        }
    }
}
