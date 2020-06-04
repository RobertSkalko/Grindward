using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes
{
    class Chilling : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "chilling";
        }

        public override string GetName()
        {
            return "Chilling";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> { 
                new VanillaStatMod(2F, 5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Frost])
            };
        }

        public override int GetWeight()
        {
            return 1000;
        }
    }
}
