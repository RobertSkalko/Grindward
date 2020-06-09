using grindward.database;
using grindward.database.affixes;
using grindward.database.affixes.suffixes;
using grindward.database.affixes.suffixes.armor;
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

        public Suffix OfMinorHealth = Reg(new OfMinorHealth());
        public Suffix OfWarmth = Reg(new OfWarmth());

        public Suffix OfBurningBrilliance = Reg(new OfBurningBrilliance());
        public Suffix OfSnakeBite = Reg(new OfSnakeBite());
        public Suffix OfNecroTouch = Reg(new OfNecroTouch());

        public Suffix OfIceBearers = Reg(new OfEleDmgRare(DamageType.Types.Frost, "Of Ice Bearers"));
        public Suffix OfFlameBearers = Reg(new OfEleDmgRare(DamageType.Types.Fire, "Of Flame Bearers"));
        public Suffix OfGhostBearers = Reg(new OfEleDmgRare(DamageType.Types.Ethereal, "Of Ghost Bearers"));
        public Suffix OfVoltBearers = Reg(new OfEleDmgRare(DamageType.Types.Electric, "Of Volt Bearers"));
        public Suffix OfVenomBearers = Reg(new OfEleDmgRare(DamageType.Types.Decay, "Of Venom Bearers"));


        static private Suffix Reg(Suffix suffix)
        {
            return Registry.Suffixes.Register(suffix);
        }
        

    }
}
