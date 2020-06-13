using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.armor
{
    class Merchants : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "merchants";
        }

        public override string GetName()
        {
            return "Merchant's";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(-7F, -15F, VanillaStats.Instance.movement),
                new VanillaStatMod(3, 12, VanillaStats.Instance.pouchBonus)

            };
        }

        public override int GetWeight()
        {
            return 150;
        }
    }
}
