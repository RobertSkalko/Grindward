using grindward.database.registers;
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
        public override List<Weighted<Tier>> GetItemTierDropChances()
        {
            return new List<Weighted<Tier>>() {
                new Weighted<Tier>(this, 100),
                new Weighted<Tier>(Tiers.Instance.Normal, 5)
            };
        }
        public override int GetTierNumber()
        {
            return 0;
        }
        public override float GetItemTierReq()
        {
            return 0;
        }

        public override float GetMobTierReq()
        {
            return 0;
        }
    }
}
