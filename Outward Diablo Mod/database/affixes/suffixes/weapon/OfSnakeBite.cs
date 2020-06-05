using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.weapon
{
    class OfSnakeBite : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "of_snake_bite";
        }

        public override string GetName()
        {
            return "Of Snake Bite";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(2, 6, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Physical]),
                new VanillaStatMod(2, 4, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Decay])
            };
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
