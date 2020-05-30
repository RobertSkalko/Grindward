using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.gear_types.weapons
{
    class TwoHandWeapon : GearType
    {
        public override string GetId()
        {
            return "two_hand_wep";
        }
        public override int GetWeight()
        {
            return 1000;
        }
        public override bool isType(Item item)
        {
            if (item is Weapon weapon)
            {
                return weapon.TwoHand == Equipment.TwoHandedType.TwoHandedLeft || weapon.TwoHand == Equipment.TwoHandedType.TwoHandedRight;
            }

            return false;
        }
    }
}
