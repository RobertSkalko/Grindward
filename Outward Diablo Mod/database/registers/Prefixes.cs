using grindward.database.affixes;
using grindward.database.affixes.prefixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.registers
{
    class Prefixes
    {
        public static Prefixes Instance;

        public Prefix Chilling = Registry.Prefixes.Register(new ElelWepDmgPrefix(DamageType.Types.Frost, "Chilling"));
        public Prefix Flaring = Registry.Prefixes.Register(new ElelWepDmgPrefix(DamageType.Types.Fire, "Flaring"));
        public Prefix Toxic = Registry.Prefixes.Register(new ElelWepDmgPrefix(DamageType.Types.Decay, "Toxic"));
        public Prefix Voltaic = Registry.Prefixes.Register(new ElelWepDmgPrefix(DamageType.Types.Electric, "Voltaic"));
        public Prefix Ghostly = Registry.Prefixes.Register(new ElelWepDmgPrefix(DamageType.Types.Ethereal, "Ghostly"));
          
            
    }
}
