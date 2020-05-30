using outward_diablo.database.affixes;
using outward_diablo.database.gear_types;
using outward_diablo.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutwardDiabloMod.database.affixes.suffixes
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
            return 1000;
        }
    }
}
