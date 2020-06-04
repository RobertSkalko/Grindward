using grindward;
using grindward.database;
using grindward.database.affixes;
using grindward.database.gear_types;
using grindward.database.registers;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace grindward
{
    public class SuffixData : BaseAffixData<Suffix>
    {
        public override Suffix GetAffix()
        {
            return Registry.Suffixes.Get(id);
        }

        public override List<Suffix> GetAll()
        {
            return Registry.Suffixes.GetAll();
        }
    }
}
