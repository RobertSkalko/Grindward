using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.armor
{
    class OfEfficiency : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "of_eff";
        }

        public override string GetName()
        {
            return "Of Efficiency";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(3, 6, VanillaStats.Instance.staminaCost),
                new VanillaStatMod(3, 6, VanillaStats.Instance.manaCost),
            };
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
