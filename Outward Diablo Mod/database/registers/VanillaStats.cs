using grindward.database.registers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.registers
{
    public class VanillaStats
    {
        public static VanillaStats Instance;
        public VanillaStats()
        {

            protections = new Dictionary<DamageType.Types, ElementVanillaStat>();
            ele_damageBoosts = new Dictionary<DamageType.Types, ElementVanillaStat>();

            foreach (DamageType.Types type in EnumUtils.Elements())
            {
                protections.Add(type, (ElementVanillaStat)Registry.VanillaStats.Register(new ElementVanillaStat(Fields.INSTANCE.EquipmentStats_m_damageProtection, type, type.ToString().ToLower() + "_" + "protection")));
                ele_damageBoosts.Add(type, (ElementVanillaStat)Registry.VanillaStats.Register(new ElementVanillaStat(Fields.INSTANCE.EquipmentStats_m_damageAttack, type, type.ToString().ToLower() + "_" + "damage_boost")));
               
            }

        }

        public Dictionary<DamageType.Types, ElementVanillaStat> protections;
        public Dictionary<DamageType.Types, ElementVanillaStat> ele_damageBoosts;
        //public Dictionary<DamageType.Types, ElementVanillaStat> eleAttackDamage;

        public BasicVanillaStat heatProtection = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_heatProtection, "heat_protection"));
        public BasicVanillaStat coldProtection = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_coldProtection, "cold_protection"));

        public BasicVanillaStat health = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_maxHealthBonus, "health"));
        
        public BasicVanillaStat movement = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_movementPenalty, "movement"));
        public BasicVanillaStat manaCost = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_manaUseModifier, "mana_cost"));
        public BasicVanillaStat staminaCost = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_staminaUsePenalty, "stamina_cost"));
        public BasicVanillaStat pouchBonus = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_pouchCapacityBonus, "pouch_bonus"));

    }
}
