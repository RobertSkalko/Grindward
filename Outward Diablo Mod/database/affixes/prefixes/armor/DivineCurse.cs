using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.armor
{
    class DivineCurse : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return  GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "div_curse";
        }

        public override string GetName()
        {
            return "Divine Curse";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {

                new VanillaStatMod(-7F, -15, VanillaStats.Instance.resistances[DamageType.Types.Electric]),
            
            };
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
