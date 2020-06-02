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

        public BasicVanillaStat(SafeField<EquipmentStats, float> info, String id) : base(id)
        {         
            this.info = info;
        }
                
        public  override void SetStat(EquipmentStats stats, float val)
        {
            info.SetValue(stats, val);
        }
        public override float GetStat(EquipmentStats stats)
        {
            return info.GetValue(stats);
        }

    }
}
