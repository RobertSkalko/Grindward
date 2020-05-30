using Microsoft.Win32;
using outward_diablo.database;
using outward_diablo.database.gear_types;
using outward_diablo.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo
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
            return item.IsEquippable && item is Equipment && item.GetComponent<EquipmentStats>() != null;

        }
    }
}