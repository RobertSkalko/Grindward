using outward_diablo.database.affixes;
using outward_diablo.database.gear_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database
{
    public static class Registry
    {
        public static RegistryHolder<VanillaStat> VanillaStats;
        public static RegistryHolder<Prefix> Prefixes;
        public static RegistryHolder<Suffix> Suffixes;
        public static RegistryHolder<GearType> GearTypes;

        public static void Init()
        {
            Suffixes = new RegistryHolder<Suffix>();
            Prefixes = new RegistryHolder<Prefix>();
            VanillaStats = new RegistryHolder<VanillaStat>();
            GearTypes = new RegistryHolder<GearType>();

        }
    }
}
