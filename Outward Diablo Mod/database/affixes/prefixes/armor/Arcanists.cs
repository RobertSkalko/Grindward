using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.armor
{
    class Arcanists : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "arcanists";
        }

        public override string GetName()
        {
            return "Arcanist's";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> { new VanillaStatMod(-3F, -5F, VanillaStats.Instance.manaCost) };
        }

        public override int GetWeight()
        {
            return 1000;
        }
    }
}
