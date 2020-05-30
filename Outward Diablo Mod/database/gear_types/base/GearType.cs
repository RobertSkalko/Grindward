using OutwardDiabloMod.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database.gear_types
{
    public abstract class GearType : RegistryEntry , IWeighted
    {
      
        public abstract bool isType(Item item);
        public abstract string GetId();
        public abstract int GetWeight();
    }
}
