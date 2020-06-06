using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.prefixes.armor
{
    public class EleEssencePrefix : Prefix
    {
        DamageType.Types type;
        string name;

        public EleEssencePrefix(DamageType.Types type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public override List<GearType> GetGearTypesAllowedOn()
        {
            return GearTypes.Instance.armors;
        }

        public override string GetId()
        {
            return type.ToString() + "_essence";
        }

        public override string GetName()
        {
            return name;
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(4, 10, VanillaStats.Instance.ele_damageBoosts[type])
            };
        }

        public override int GetWeight()
        {
            return 1000 / EnumUtils.NON_PHYS_ELEMENTS_COUNT;
        }
    }
}
