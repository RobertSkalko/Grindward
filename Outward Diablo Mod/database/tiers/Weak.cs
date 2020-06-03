using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.tiers
{
    class Weak : Tier
    {
        public override string GetId()
        {
            return "weak";
        }

        public override int GetTierNumber()
        {
            return 0;
        }
        public override float GetTierReq()
        {
            return 0;
        }
    }
}
