using grindward.database.gear_types;
using grindward;
using grindward.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public abstract class Affix : RegistryEntry , IWeighted
    {

        public abstract List<GearType> GetGearTypesAllowedOn();
        public abstract List<VanillaStatMod> GetVanillaStatMods();

        public bool CanBeOnGearType(GearType type)
        {
            return GetGearTypesAllowedOn().Any(x => x.GetId().Equals(type.GetId()));
        }

        public abstract string GetId();

        public abstract int GetWeight();

        public abstract String GetName();
    }
}
