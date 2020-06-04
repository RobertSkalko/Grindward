using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace grindward.database.registers.Base
{
   public  class BasicVanillaStat : VanillaStat
    {
        SafeField<EquipmentStats, float> info;

        public BasicVanillaStat(SafeField<EquipmentStats, float> info, String id, int place, VanillaStat.Type stattype) : base(id,place, stattype)
        {         
            this.info = info;
        }
                
        public  override void SetStat(Equipment item, float val)
        {
            info.SetValue(item.Stats, val);
        }
        public override float GetStat(Equipment item)
        {
            return info.GetValue(item.Stats);
        }

    
    }
}
