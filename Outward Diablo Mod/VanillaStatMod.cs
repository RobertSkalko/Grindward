using outward_diablo.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutwardDiabloMod
{
    public class VanillaStatMod
    {

        float min;
        float max;
        VanillaStat stat;

        public VanillaStatMod(float min, float max, VanillaStat stat)
        {
            this.min = min;
            this.max = max;
            this.stat = stat ?? throw new ArgumentNullException(nameof(stat));
        }

            
        public void ApplyToItem(int percent, Equipment item)
        {
            int val = (int)GetValue(percent);

            stat.SetStat(item.Stats, stat.GetStat(item.Stats) + val);

        }

        public float GetValue(int percent)
        {
            return min + ((max - min) * percent / 100);
            
        }
      

    }
}
