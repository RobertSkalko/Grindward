using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class IncreaseRandomStats : ItemChanger
    {
        int amount = 5;

        public IncreaseRandomStats(int amount = 5)
        {
            this.amount = amount;
        }

        public override void ChangeItem(Equipment item)
        {
              DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

                ext.randomStats.AddToAllPercents(item, amount);

            
        }
        public override string GetChatNotification()
        {
            return "Your item's stats have recieved a boost.";
        }

        public override string GetDescription()
        {
            return "Increases the random stats by " + amount + ".";
        }
    }
}
