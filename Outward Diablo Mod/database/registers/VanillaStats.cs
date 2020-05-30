using outward_diablo.database.registers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.registers
{
    public class VanillaStats
    {
        public static VanillaStats Instance;
        public VanillaStats()
        {

            protections = new Dictionary<DamageType.Types, ElementVanillaStat>();

            foreach (DamageType.Types type in EnumUtils.Elements())
            {
              
                protections.Add(type, (ElementVanillaStat)Registry.VanillaStats.Register(new ElementVanillaStat(Fields.INSTANCE.EquipmentStats_m_damageProtection,type, type.ToString().ToLower() + "_" + "protection")));

            }

        }

        public Dictionary<DamageType.Types, ElementVanillaStat> protections;

        public BasicVanillaStat heatProtection = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_heatProtection, "heat_protection"));
        public BasicVanillaStat coldProtection = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_coldProtection, "cold_protection"));
        public BasicVanillaStat health = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_maxHealthBonus, "health"));

    }
}
