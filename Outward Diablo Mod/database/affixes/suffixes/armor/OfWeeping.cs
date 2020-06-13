using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.armor
{
    class OfWeeping : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "of_weeping";
        }

        public override string GetName()
        {
            return "Of Weeping";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(-5, -15, VanillaStats.Instance.resistances[DamageType.Types.Ethereal])
              };
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
