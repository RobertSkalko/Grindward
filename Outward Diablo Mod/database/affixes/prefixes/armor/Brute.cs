using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.armor
{
    class Brute : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "brute";
        }

        public override string GetName()
        {
            return "Brute's";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {

                new VanillaStatMod(2, 5, VanillaStats.Instance.ele_damageBoosts[DamageType.Types.Physical]),
                new VanillaStatMod(5, 10, VanillaStats.Instance.manaCost)

            };
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
