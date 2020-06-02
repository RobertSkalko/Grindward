


using grindward.database.registers;
using grindward.database.registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database
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
