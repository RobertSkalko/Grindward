using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.weapon
{
    class OfHarshWinter : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "of_harsh_winter";
        }

        public override string GetName()
        {
            return "Of Harsh Winter";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(5, 10, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Frost])              
            };
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
