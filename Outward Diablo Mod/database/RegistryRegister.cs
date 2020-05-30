


using outward_diablo.database.registers;
using OutwardDiabloMod.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.database
{
    class RegistryRegister
    {

        public static void RegisterAll()
        {
            VanillaStats.Instance = new VanillaStats();
            GearTypes.Instance = new GearTypes();
            Suffixes.Instance = new Suffixes();

        }
    }
}
