using grindward.database.tiers;
using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.registers
{
    class Tiers
    {
        public static Tiers Instance;

        public Tier Weak = Registry.Tiers.Register(new Weak());
        public Tier Normal = Registry.Tiers.Register(new Normal());
        public Tier HighEnd = Registry.Tiers.Register(new HighEnd());
        public Tier Endgame = Registry.Tiers.Register(new Endgame());
        
    }
}
