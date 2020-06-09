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

                /*
                SL_WeaponStats holder = new SL_WeaponStats();
                SL_WeaponStats.ParseWeaponStats(wep.Stats, holder);

                int index = (int)type;

                var opt = holder.BaseDamage.Find(x => x.Type == type);

                if (opt == null)
                {
                    SL_Damage dmg = new SL_Damage();
                    dmg.Type = type;
                    dmg.Damage = val;

                    holder.BaseDamage.Add(dmg);
                }
                else
                {
                    opt.Damage = val;
                }          

                holder.ApplyToItem(wep.Stats);
                */

               
                if (wep.Stats.BaseDamage.Contains(type))
                {
                    wep.Stats.BaseDamage[type].Damage = val;

                    if (wep.Stats.BaseDamage[type].Damage == 0)
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
