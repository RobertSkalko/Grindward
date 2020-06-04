using Microsoft.Win32;
using grindward.database;
using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using grindward.utils;
using SideLoader;

namespace grindward
{
    public class ItemUtils { 


        public static Dictionary<string, Item> GetAllItemPrefabs()
        {
            return CustomItems.RPM_ITEM_PREFABS;
                  

                
        }

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
            if (Cached.Instance.ITEM_IS_GEAR.ContainsKey(item.ItemID))
            {
                return Cached.Instance.ITEM_IS_GEAR[item.ItemID];
            }
                      
           
            if (!item.IsEquippable || !(item is  Equipment) || item.GetComponent<EquipmentStats>() == null)
            {
                return false;               
                //return LogWhy(item, "Not equipment", log);
            }

           
                String name = item.Name.ToLower();

                if (item.Stats == null)
                {
                return LogWhy(item, "No item stats", log);
                }
                if (name.Length < 3)
                {
                    return LogWhy(item, "Name Length too short", log);
                }
                else if (item.ItemID < 1000000)
                {
                    return LogWhy(item, "ID is lower than x amount, means it's a dev item", log);
                }
                else if (name.Contains("test") || name.Contains("standard"))
                {
                    return LogWhy(item, "Name contains test or standard", log);
                }
                else if (item.ItemIcon == ItemManager.Instance.DefaultItemIcon
                     || item.ItemIcon == ItemManager.Instance.DefaultEquipmentIcon
                     || item.ItemIcon == ItemManager.Instance.DefaultWeaponIcon
                     || item.ItemIcon == ItemManager.Instance.DefaultAnyIngredientIcon
                     || item.ItemIcon == ItemManager.Instance.DefaultConsumableIcon
                     )
                {
                    return LogWhy(item, "Icon is default", log);
                }
                else if (item.Tags != null && item.Tags.Any(x => x.TagName.ToLower().Contains("monster")))
                {
                    return LogWhy(item, "Tag contains monster", log);
                }
            
          
            Cached.Instance.ITEM_IS_GEAR.Add(item.ItemID, true);

            return true;
        }

        private static bool LogWhy(Item item, String reason, bool log)
        {
            if (log)
            {
                Log.Debug(item.Name + " failed because: " + reason + " . ID: " + item.ItemID);
            }

            Cached.Instance.ITEM_IS_GEAR.Add(item.ItemID, false);


            return false;

        }
    }
}