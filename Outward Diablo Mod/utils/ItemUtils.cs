using Microsoft.Win32;
using grindward.database;
using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using grindward.utils;

namespace grindward
{
    class ItemUtils { 

        public static GearType GetGearType(Item item)
    {
          foreach( GearType type in database.Registry.GearTypes.GetAll()){
                if (type.isType(item))
                {
                    return type;
                }

            }
            return null;

    }

        public static bool IsGear(Item item, bool log = false)
        {
            if (!item.IsEquippable || !(item is  Equipment) || item.GetComponent<EquipmentStats>() == null)
            {
                return false;
                //return LogWhy(item, "Not equipment", log);
            }

            String name = item.Name.ToLower();

            if (name.Length < 3)
            {
                return LogWhy(item, "Name Length too short", log);
            }
            if (item.ItemID < 1000000)
            {
                return LogWhy(item, "ID is lower than x amount, means it's a dev item", log);
            }
            if (name.Contains("test") || name.Contains("standard"))
            {
                return LogWhy(item, "Name contains test or standard", log);
            }           
            if (item.ItemIcon == ItemManager.Instance.DefaultItemIcon 
                || item.ItemIcon == ItemManager.Instance.DefaultEquipmentIcon
                || item.ItemIcon == ItemManager.Instance.DefaultWeaponIcon
                || item.ItemIcon == ItemManager.Instance.DefaultAnyIngredientIcon
                || item.ItemIcon == ItemManager.Instance.DefaultConsumableIcon
                )
            {
                return LogWhy(item, "Icon is default", log);
            }
            if (item.Tags != null && item.Tags.Any(x => x.TagName.ToLower().Contains("monster")))
            {
                return LogWhy(item, "Tag contains monster", log);
            }

            return true;
        }

        private static bool LogWhy(Item item, String reason, bool log)
        {
            if (log)
            {
                Log.Debug(item.Name + " failed because: " + reason + " . ID: " + item.ItemID);
            }

           return false;

        }
    }
}