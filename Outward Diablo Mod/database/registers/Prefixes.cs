using grindward.database.affixes;
using grindward.database.affixes.prefixes;
using grindward.database.affixes.prefixes.armor;
using grindward.database.affixes.prefixes.weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.registers
{
    class Prefixes
    {
        public static Prefixes Instance;

        public Prefix Chilling = Reg(new ElelWepDmgPrefix(DamageType.Types.Frost, "Chilling"));
        public Prefix Flaring = Reg(new ElelWepDmgPrefix(DamageType.Types.Fire, "Flaring"));
        public Prefix Toxic = Reg(new ElelWepDmgPrefix(DamageType.Types.Decay, "Toxic"));
        public Prefix Voltaic = Reg(new ElelWepDmgPrefix(DamageType.Types.Electric, "Voltaic"));
        public Prefix Ghostly = Reg(new ElelWepDmgPrefix(DamageType.Types.Ethereal, "Ghostly"));

        public Prefix FrostEssence = Reg(new EleEssencePrefix(DamageType.Types.Frost, "Frost Essence"));
        public Prefix FlameEssence = Reg(new EleEssencePrefix(DamageType.Types.Fire, "Flame Essence"));
        public Prefix VoltaicEssence = Reg(new EleEssencePrefix(DamageType.Types.Electric, "Voltaic Essence"));
        public Prefix GhostEssence = Reg(new EleEssencePrefix(DamageType.Types.Ethereal, "Ghost Essence"));
        public Prefix DecayEssence = Reg(new EleEssencePrefix(DamageType.Types.Decay, "Decay Essence"));

        public Prefix Arcanists = Reg(new Arcanists());
        public Prefix Acrobats = Reg(new Acrobats());

        public Prefix Brute = Reg(new Brute());
        public Prefix DivineCurse = Reg(new DivineCurse());
        public Prefix Plain = Reg(new Plain());
        

        static private Prefix Reg(Prefix prefix)
        {
            return Registry.Prefixes.Register(prefix);
        }
    }
}
