using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database.tiers
{
    class Endgame : Tier
    {
        public override string GetId()
        {
            return "endgame";
        }

        public override int GetTierNumber()
        {
            return 3;
        }

        public override float GetTierReq()
        {
            return 0.7F;
        }
    }
}

