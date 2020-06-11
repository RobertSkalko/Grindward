using grindward.database.registers;
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
        public override List<Weighted<Tier>> GetItemTierDropChances()
        {
            return new List<Weighted<Tier>>() {
                new Weighted<Tier>(this, 100),
                new Weighted<Tier>(Tiers.Instance.Endgame, 5),
                new Weighted<Tier>(Tiers.Instance.Normal, 5),
            };
        }
        public override int GetTierNumber()
        {
            return 2;
        }
        public override float GetItemTierReq()
        {
            return 0.5F;
        }
        public override float GetMobTierReq()
        {
            return 2.5F;
        }
        public override int GetWeight()
        {
            return 150;
        }
    }
}
