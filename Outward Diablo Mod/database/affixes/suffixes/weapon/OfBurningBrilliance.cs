using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.weapon
{
    class OfBurningBrilliance : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "of_burn_brill";
        }

        public override string GetName()
        {
            return "Of Burning Brilliance";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(2, 4, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Fire]),
                new VanillaStatMod(2, 4, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Electric])
            };
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
