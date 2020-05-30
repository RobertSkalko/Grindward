using outward_diablo.database.affixes;
using outward_diablo.database.gear_types;
using outward_diablo.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutwardDiabloMod.database.affixes.suffixes
{
    class OfWarmth : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "of_warmth";
        }

        public override string GetName()
        {
            return "Of Warmth";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> { new VanillaStatMod(2F, 5F, VanillaStats.Instance.coldProtection) };
        }

        public override int GetWeight()
        {
            return 1000;
        }
    }
}
