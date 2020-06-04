using grindward.database.registers.Base;
using grindward.database.vanilla_stats.Base;
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
            eleAttackDamage = new Dictionary<DamageType.Types, WeaponVanillaStat>();
            resistances = new Dictionary<DamageType.Types, ElementVanillaStat>();

            int index = 1000;

            foreach (DamageType.Types type in EnumUtils.Elements())
            {
                protections.Add(type, (ElementVanillaStat)Registry.VanillaStats.Register(new ElementVanillaStat(Fields.INSTANCE.EquipmentStats_m_damageProtection, type, type.ToString().ToLower() + "" + "protection", index++,VanillaStat.Type.ArmorStat)));
                ele_damageBoosts.Add(type, (ElementVanillaStat)Registry.VanillaStats.Register(new ElementVanillaStat(Fields.INSTANCE.EquipmentStats_m_damageAttack, type, type.ToString().ToLower() + "" + "damageboost", index++, VanillaStat.Type.GearStat)));
                eleAttackDamage.Add(type, (WeaponVanillaStat)Registry.VanillaStats.Register(new WeaponVanillaStat(type, type.ToString().ToLower() + "" + "attackdamage", index++, VanillaStat.Type.WeaponStat)));
                resistances.Add(type, (ElementVanillaStat)Registry.VanillaStats.Register(new ElementVanillaStat(Fields.INSTANCE.EquipmentStats_m_damageResistance, type, type.ToString().ToLower() + "" + "resistance", index++, VanillaStat.Type.GearStat)));
                
            }
        }

        public List<VanillaStat> GetAllStatsOrderedByIndex()
        {
            List<VanillaStat> all = Registry.VanillaStats.GetAll();
            all.Sort();
            return all;

        }

        public List<VanillaStat> GetAllStatsItemHasOrderedByIndex(Equipment item)
        {
            return GetAllStatsOrderedByIndex().Where(x => x.GetStat(item) != 0).ToList();
        }

        public Dictionary<DamageType.Types, ElementVanillaStat> protections;
        public Dictionary<DamageType.Types, ElementVanillaStat> resistances;
        public Dictionary<DamageType.Types, ElementVanillaStat> ele_damageBoosts;
        public Dictionary<DamageType.Types, WeaponVanillaStat> eleAttackDamage;

        public BasicVanillaStat heatProtection = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_heatProtection, "heatprot",0, VanillaStat.Type.ArmorStat));
        public BasicVanillaStat coldProtection = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_coldProtection, "coldprot",1, VanillaStat.Type.ArmorStat));

        public BasicVanillaStat health = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_maxHealthBonus, "health",2, VanillaStat.Type.ArmorStat));
        
        public BasicVanillaStat movement = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_movementPenalty, "movement",3, VanillaStat.Type.ArmorStat));
        public BasicVanillaStat manaCost = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_manaUsePenalty, "manacost",4, VanillaStat.Type.GearStat));
        public BasicVanillaStat staminaCost = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_staminaUsePenalty, "staminacost",5, VanillaStat.Type.GearStat));
        public BasicVanillaStat pouchBonus = (BasicVanillaStat)Registry.VanillaStats.Register(new BasicVanillaStat(Fields.INSTANCE.EquipmentStats_m_pouchCapacityBonus, "pouchbonus",6, VanillaStat.Type.ArmorStat));

    }
}
