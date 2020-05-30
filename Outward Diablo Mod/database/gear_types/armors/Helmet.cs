using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.gear_types
{
   public class Helmet : GearType
    {
        public override string GetId()
        {
            return "helmet";
        }

        public override bool isType(Item item)
        {
            if (item is Armor armor)
            {
                return armor.EquipSlot == EquipmentSlot.EquipmentSlotIDs.Helmet;
            }

            return false;
        }
    }
}
