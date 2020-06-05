using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes
{
    class OfNecroTouch : Suffix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "of_necro_touch";
        }

        public override string GetName()
        {
            return "Of Necrotic Touch";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(2, 4, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Frost]),
                new VanillaStatMod(2, 4, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Ethereal])
            };
        }

        public override int GetWeight()
        {
            return 200;
        }
    }
}
