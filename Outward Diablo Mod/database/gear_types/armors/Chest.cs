using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.gear_types
{
    class Chest : GearType
    {
        public override string GetId()
        {
            return "chest";
        }

        public override int GetWeight()
        {
            return 1000;
        }

        public override bool isType(Item item)
        {
            if (item is Equipment armor)
            {
                return armor.EquipSlot == EquipmentSlot.EquipmentSlotIDs.Chest;
            }

            return false;
        }
    }
}
