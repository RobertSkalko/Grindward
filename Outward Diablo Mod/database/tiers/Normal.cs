using grindward.database.registers;
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
        public override List<Weighted<Tier>> GetItemTierDropChances()
        {
            return new List<Weighted<Tier>>() {
                new Weighted<Tier>(this, 100),
                new Weighted<Tier>(Tiers.Instance.Weak, 40),
                new Weighted<Tier>(Tiers.Instance.HighEnd, 3),
            };
        }
        public override int GetTierNumber()
        {
            return 1;
        }
        public override float GetItemTierReq()
        {
            return 0.3F;
        }
        public override float GetMobTierReq()
        {
            return 1.75F;
        }
        public override int GetWeight()
        {
            return 500;
        }
        public override MinMax GetRandomStatsPercents()
        {
            return new MinMax(50, MAX_RANDOM_PERCENT);
        }
        public override string GetItemTierName()
        {
            return "Rare";
        }
    }
}
