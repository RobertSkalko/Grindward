using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.armor
{
    class Acrobats : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return new List<GearType>() { GearTypes.Instance.helmet };
        }

        public override string GetId()
        {
            return "acrobats";
        }

        public override string GetName()
        {
            return "Acrobat's";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> { new VanillaStatMod(-3F, -5F, VanillaStats.Instance.staminaCost) };
        }

        public override int GetWeight()
        {
            return 222;
        }
    }
}
