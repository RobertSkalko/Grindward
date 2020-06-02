using grindward.database;
using grindward.database.affixes;
using grindward.database.affixes.suffixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.registers
{
    public class Suffixes
    {
        public static Suffixes Instance;

        public Suffix OfMinorHealth = Registry.Suffixes.Register(new OfMinorHealth());
        public Suffix OfWarmth = Registry.Suffixes.Register(new OfWarmth());

    }
}
