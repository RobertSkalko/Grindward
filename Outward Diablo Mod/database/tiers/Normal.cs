using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.tiers
{
    class Normal : Tier
    {
        public override string GetId()
        {
            return "normal";
        }

        public override int GetTierNumber()
        {
            return 1;
        }
        public override float GetTierReq()
        {
            return 0.5F;
        }
    }
}
