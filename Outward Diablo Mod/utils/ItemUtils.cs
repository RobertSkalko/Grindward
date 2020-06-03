using Microsoft.Win32;
using grindward.database;
using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static bool IsGear(Item item)
        {

            if (item.Name.Length < 3)
            {
                return false;
            }
            if (item.Name.ToLower().Contains("standard"))
            {
                return false;
            }     
            if (Fields.INSTANCE.Item_Icon.GetValue(item) == null)
            {
                return false;
            }
            if (item.Tags != null && item.Tags.Any(x => x.TagName.ToLower().Contains("monster")))
            {
                return false;
            }

            return item.IsEquippable && item is Equipment && item.GetComponent<EquipmentStats>() != null;

        }
    }
}