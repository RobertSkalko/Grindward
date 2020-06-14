using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.ambush_penalties
{
    class PranksterPoison : AmbushPenalty
    {
        public override void act(Character player)
        {
            player.AddStatusEffect(AmbushPenalty.FOOD_POISONING);
            player.AddStatusEffect(AmbushPenalty.POISONED);

            player.PlayerStats.Food -= player.PlayerStats.MaxFood / 5;
            player.PlayerStats.Drink -= player.PlayerStats.MaxDrink / 5;
        }

        public override string GetNotification()
        {
            return "You wake up feeling sick, someone must have poisoned you!";
        }

        public override int GetWeight()
        {
            return 1000;
        }
    }
}
