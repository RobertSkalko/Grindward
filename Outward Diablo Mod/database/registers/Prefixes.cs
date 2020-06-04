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

        public Prefix Chilling = Registry.Prefixes.Register(new Chilling());
       
    }
}
