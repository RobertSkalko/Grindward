using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class EnumUtils
    {

        public static int NON_PHYS_ELEMENTS_COUNT = 5;
        public static int ALL_ELEMENTS_COUNT = 6;

        public static List<DamageType.Types> Elements()
        {
            return  new List<DamageType.Types> { DamageType.Types.Decay, DamageType.Types.Electric, DamageType.Types.Ethereal, DamageType.Types.Frost, DamageType.Types.Fire, DamageType.Types.Physical };
            
        }

        public static List<DamageType.Types> GetOnlyElements()
        {
            return new List<DamageType.Types> { DamageType.Types.Decay, DamageType.Types.Electric, DamageType.Types.Ethereal, DamageType.Types.Frost, DamageType.Types.Fire};

        }

    }
}
