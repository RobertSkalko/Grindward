using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.tiers
{
    class HighEnd : Tier
    {
        public override string GetId()
        {
            return "highend";
        }

        public override int GetTierNumber()
        {
            return 2;
        }
        public override float GetTierReq()
        {
            return 0.5F;
        }
    }
}
