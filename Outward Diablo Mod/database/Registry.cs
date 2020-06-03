using grindward.database.affixes;
using grindward.database.gear_types;
using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database
{
    public static class Registry
    {
        public static RegistryHolder<VanillaStat> VanillaStats;
        public static RegistryHolder<Prefix> Prefixes;
        public static RegistryHolder<Suffix> Suffixes;
        public static RegistryHolder<Tier> Tiers;
        public static RegistryHolder<GearType> GearTypes;

        public static void Init()
        {
            Suffixes = new RegistryHolder<Suffix>();
            Prefixes = new RegistryHolder<Prefix>();
            VanillaStats = new RegistryHolder<VanillaStat>();
            GearTypes = new RegistryHolder<GearType>();
            Tiers = new RegistryHolder<Tier>();

        }
    }
}
