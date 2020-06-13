using SideLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace grindward.database.vanilla_stats.Base
{
   public class WeaponVanillaStat : VanillaStat
    {
         DamageType.Types type;

        public WeaponVanillaStat(DamageType.Types type, String id, int place, VanillaStat.Type stattype) : base(id,place, stattype)
        {           
            this.type = type;         
        }

        public override void SetStat(Equipment item, float val)
        {
            if (item is Weapon wep) {
               
                if (wep.Stats.BaseDamage.Contains(type))
                {
                    wep.Stats.BaseDamage[type].Damage = val;

                    if (wep.Stats.BaseDamage[type].Damage < 1) // dont do damages in minus or show zero damage
                    {
                        wep.Stats.BaseDamage.Remove(type); // so it doesnt show on tooltips
                    }

                }
                else
                {
                    wep.Stats.BaseDamage.Add(new DamageType(type, val));                                         
                }              
                              
               

                wep.Stats.Attacks = SL_WeaponStats.GetScaledAttackData(wep);

                wep.InitCachedInfos();

            }
        }
        public override float GetStat(Equipment item)
        {
            if (item.Stats is WeaponStats stats)
            {                
                if (item is Weapon weapon)
                {                  
                    if (stats.BaseDamage.Contains(type))
                    {
                        return stats.BaseDamage[type].Damage;
                    }                    
                }                               
            }
           
           return 0;
        }
    }

}
