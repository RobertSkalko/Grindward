using grindward.database.affixes;
using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes
{
    class OfMinorHealth : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "of_minor_hp";
        }

        public override string GetName()
        {
            return "Of Minor Health";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {new VanillaStatMod(4F, 8F, VanillaStats.Instance.health)};
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
