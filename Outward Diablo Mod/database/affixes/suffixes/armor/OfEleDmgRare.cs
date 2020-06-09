using grindward.database.gear_types;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.affixes.suffixes.armor
{
   public class OfEleDmgRare : Suffix
    {
        DamageType.Types type;
        string name;

        public OfEleDmgRare(DamageType.Types type, string name)
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
            return type.ToString() + "_ele_dmg_rare";
        }

        public override string GetName()
        {
            return name;
        }

        public override List<VanillaStatMod> GetVanillaStatMods()
        {
            return new List<VanillaStatMod> {
                new VanillaStatMod(5, 12, VanillaStats.Instance.ele_damageBoosts[type]),
                new VanillaStatMod(4, 15, VanillaStats.Instance.resistances[type])
            };
        }

        public override int GetWeight()
        {
            return 150 / EnumUtils.NON_PHYS_ELEMENTS_COUNT;
        }
    }
}
