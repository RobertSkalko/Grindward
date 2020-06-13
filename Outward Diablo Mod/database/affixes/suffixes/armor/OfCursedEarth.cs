using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.armor
{
    class OfCursedEarth : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return "of_curse_earth";
        }

        public override string GetName()
        {
            return "Of Cursed Earth";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(2F, 5F, VanillaStats.Instance.ele_damageBoosts[DamageType.Types.Ethereal]),
                new VanillaStatMod(-5, -10, VanillaStats.Instance.resistances[DamageType.Types.Fire])
              };
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
