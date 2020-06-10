using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class ChanceToIncreaseStats : ItemChanger
    {
        int chance;
        int amount = 5;

        public ChanceToIncreaseStats(int chance, int amount = 5)
        {
            this.chance = chance;
        }

        public override void ChangeItem(Equipment item)
        {
            if (RandomUtils.Roll(chance))
            {
                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

                ext.randomStats.AddToAllPercents(item, amount);

            }
        }

        public override string GetDescription()
        {
            return chance + "% Chance to Increase the random stats by " + amount + ".";
        }
    }
}
