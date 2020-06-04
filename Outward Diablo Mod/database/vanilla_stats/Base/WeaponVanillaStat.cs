using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.vanilla_stats.Base
{
   public class WeaponVanillaStat : VanillaStat
    {
         DamageType.Types type;

        public WeaponVanillaStat(DamageType.Types type, String id) : base(id)
        {           
            this.type = type;
        }

        public override void SetStat(EquipmentStats stats, float val)
        {
            if (stats is WeaponStats wep)
            {
                foreach (WeaponStats.AttackData data in wep.Attacks)
                {
                    data.Damage[(int)type] = val;
                }

                wep.BaseDamage[type].Damage = val;
            }         
        }
        public override float GetStat(EquipmentStats stats)
        {            
            if (stats is WeaponStats wepstats)
            {
                if (Fields.INSTANCE.ItemStats_Item.GetValue(wepstats) is Weapon wep)
                {
                    return wep.GetDamageOfType(type);
                }                                
            }

            return 0;
        }


    }

}
