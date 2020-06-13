using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.weapon
{
    class Plain : Prefix
    {
        public override List<GearType> GetGearTypesAllowedOn()
        {
            return  GearTypes.Instance.weapons;
        }

        public override string GetId()
        {
            return "plain";
        }

        public override string GetName()
        {
            return "Plain";
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(3F, 5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Physical]),
                new VanillaStatMod(-3F, -5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Fire]),
                new VanillaStatMod(-3F, -5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Frost]),
                new VanillaStatMod(-3F, -5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Electric]),
                new VanillaStatMod(-3F, -5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Decay]),
                new VanillaStatMod(-3F, -5F, VanillaStats.Instance.eleAttackDamage[DamageType.Types.Ethereal])

};
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
