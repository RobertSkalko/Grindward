using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.armor
{
    class OfExcessiveCold : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "of_exc_cold";
        }

        public override string GetName()
        {
            return "Of Excessive Cold";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(-4, -10, VanillaStats.Instance.coldProtection),
                new VanillaStatMod(3, 6, VanillaStats.Instance.ele_damageBoosts[DamageType.Types.Frost])
              };
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
