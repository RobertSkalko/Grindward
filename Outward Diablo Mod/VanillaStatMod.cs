using grindward.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
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

            if (item.TwoHanded)
            {
                val *= 2; // if it's 2 handed weapon, make the stat boost double.
            }

            stat.SetStat(item, stat.GetStat(item) + val);

        }

        public float GetValue(int percent)
        {
            return min + ((max - min) * percent / 100);
            
        }
      

    }
}
