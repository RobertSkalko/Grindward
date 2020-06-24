using grindward.database.registers;
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

        public override List<Weighted<Tier>> GetItemTierDropChances()
        {
            return new List<Weighted<Tier>>() {
                new Weighted<Tier>(this, 40),
                new Weighted<Tier>(Tiers.Instance.HighEnd, 20),
                new Weighted<Tier>(Tiers.Instance.Normal, 10)
            };
        }

        public override int GetTierNumber()
        {
            return 3;
        }

        public override float GetItemTierReq()
        {
            return 0.8F;
        }
        public override float GetMobTierReq()
        {
            return 6;
        }

        public override int GetWeight()
        {
            return 50;
        }
        public override MinMax GetRandomStatsPercents()
        {
            return new MinMax(40, MAX_RANDOM_PERCENT + 10);
        }

        public override string GetItemTierName()
        {
            return "Legendary";
        }
    }
}

