using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.gear_types
{
    class Chest : GearType
    {
        public override string GetId()
        {
            return "chest";
        }

        public override bool isType(Item item)
        {
            if (item is Armor armor)
            {
                return armor.EquipSlot == EquipmentSlot.EquipmentSlotIDs.Chest;
            }

            return false;
        }
    }
}
