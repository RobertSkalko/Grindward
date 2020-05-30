using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace outward_diablo.database.registers.Base
{
   public class ElementVanillaStat : VanillaStat
    {
        SafeField<EquipmentStats, float[]> info;
        DamageType.Types type;

        public ElementVanillaStat(SafeField<EquipmentStats, float[]> info, DamageType.Types type,String id) : base(id)
        {
            this.info = info;
            this.type = type;
        }

        public override void SetStat(EquipmentStats stats, float val)
        {
            float[] vals = info.GetValue(stats);

            vals[(int)type] = val;

            info.SetValue(stats, vals);
        }
        public override float GetStat(EquipmentStats stats)
        {
            return info.GetValue(stats)[(int)type];
        }

    
}

}
