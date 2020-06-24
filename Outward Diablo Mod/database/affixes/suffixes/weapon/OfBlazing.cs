using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.weapon
{
    class OfBlazing : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "of_blazing";
        }

        public override string GetName()
        {
            return "Of Blazing";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(5, 10, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Fire])
            };
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
