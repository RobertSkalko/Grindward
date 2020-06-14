using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.ambush_penalties
{
    class WitchEleVulne : AmbushPenalty
    {
        public override void act(Character player)
        {
            player.AddStatusEffect(AmbushPenalty.ELE_VULNERABILITY);
            player.AddStatusEffect(AmbushPenalty.DIZZY);

        }

        public override string GetNotification()
        {
            return "You wake up feeling dizzy, and notice you've been cursed!";
        }

        public override int GetWeight()
        {
            return 500;
        }
    }
}
