using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace grindward.database.registers.Base
{
   public class ElementVanillaStat : VanillaStat
    {
        SafeField<EquipmentStats, float[]> info;
        DamageType.Types type;

        public ElementVanillaStat(SafeField<EquipmentStats, float[]> info, DamageType.Types type,String id,int place, VanillaStat.Type stattype) : base(id,place, stattype)
        {
            this.info = info;
            this.type = type;
        }

        public override void SetStat(Equipment item, float val)
        {
            float[] vals = info.GetValue(item.Stats);

            vals[(int)type] = val;

            info.SetValue(item.Stats, vals);
        }
        public override float GetStat(Equipment item)
        {
            return info.GetValue(item.Stats)[(int)type];
        }

    
}

}
