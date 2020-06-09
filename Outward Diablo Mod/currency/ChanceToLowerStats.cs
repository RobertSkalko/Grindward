using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class ChanceToLowerStats : ItemChanger
    {
        int chance;

        public ChanceToLowerStats(int chance)
        {
            this.chance = chance;
        }

        public override void ChangeItem(Equipment item)
        {
            if (RandomUtils.Roll(chance))
            {
                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();
                            
                ext.randomStats.AddToAllPercents(item,-5);

            }
        }

        public override string GetDescription()
        {
            return chance + "% Chance to Lower the random stats.";
        }
    }
}
