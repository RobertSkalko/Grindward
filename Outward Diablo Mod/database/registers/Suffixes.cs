using grindward.database;
using grindward.database.affixes;
using grindward.database.affixes.suffixes;
using grindward.database.affixes.suffixes.weapon;
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

        public Suffix OfBurningBrilliance = Registry.Suffixes.Register(new OfBurningBrilliance());
        public Suffix OfSnakeBite = Registry.Suffixes.Register(new OfSnakeBite());
        public Suffix OfNecroTouch = Registry.Suffixes.Register(new OfNecroTouch());

    }
}
