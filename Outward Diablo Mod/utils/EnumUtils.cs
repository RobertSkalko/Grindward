using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    class EnumUtils
    {

        public static List<DamageType.Types> Elements()
        {
            return  new List<DamageType.Types> { DamageType.Types.Decay, DamageType.Types.Electric, DamageType.Types.Ethereal, DamageType.Types.Frost, DamageType.Types.Fire, DamageType.Types.Physical };
            
        }

    }
}
