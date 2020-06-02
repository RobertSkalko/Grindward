using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database
{
    public abstract class VanillaStat : RegistryEntry
    {
      
        string id;

        public VanillaStat(String id)
        {
            this.id = id;
        }

        public abstract void SetStat(EquipmentStats stats, float val);
        public abstract float GetStat(EquipmentStats stats);
        public  string GetId()
        {
            return id;
        }

    }
}
