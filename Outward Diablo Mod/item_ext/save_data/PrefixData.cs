using grindward.database;
using grindward.database.affixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class PrefixData   : BaseAffixData<Prefix>
    {
        public override Prefix GetAffix()
        {
            return Registry.Prefixes.Get(id);
        }

        public override List<Prefix> GetAll()
        {
            return Registry.Prefixes.GetAll();
        }
    }
}

