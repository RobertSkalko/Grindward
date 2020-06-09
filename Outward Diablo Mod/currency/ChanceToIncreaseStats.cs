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

        public ChanceToIncreaseStats(int chance)
        {
            this.chance = chance;
        }

        public override void ChangeItem(Equipment item)
        {
            if (RandomUtils.Roll(chance))
            {
                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

                ext.randomStats.AddToAllPercents(item, 5);

            }
        }

        public override string GetDescription()
        {
            return chance + "% Chance to Increase the random stats.";
        }
    }
}
