using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.gear_types
{
    class Boots : GearType
    {
        public override string GetId()
        {
            return "boots";
        }

        public override bool isType(Item item)
        {
            if (item is Armor armor)
            {
                return armor.EquipSlot == EquipmentSlot.EquipmentSlotIDs.Foot;
            }

            return false;
        }
    }
}
