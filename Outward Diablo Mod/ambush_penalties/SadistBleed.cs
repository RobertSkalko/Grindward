using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.ambush_penalties
{
    class SadistBleed : AmbushPenalty
    {
        public override void act(Character player)
        {
            player.AddStatusEffect(AmbushPenalty.BLEED);
            player.AddStatusEffect(AmbushPenalty.DIZZY);

        }

        public override string GetNotification()
        {
            return "A painful stab woke you up, you seem to be bleeding!";
        }

        public override int GetWeight()
        {
            return 1000;
        }
    }
}
