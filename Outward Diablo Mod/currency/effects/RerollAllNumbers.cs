using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency.effects
{
    class RerollAllNumbers : ItemChanger
    {

        public override void ChangeItem(Equipment item)
        {
            DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

            if (ext.HasPrefix())
            {
                ext.prefix.RandomizeNumbers(item);
            }
            if (ext.HasSuffix())
            {
                ext.suffix.RandomizeNumbers(item);
            }

            ext.randomStats.Randomize(item);

        }

        public override string GetChatNotification()
        {
            return "Item values have been re-rolled.";
        }

        public override string GetDescription()
        {
            return "Re-rolls all stat numbers.";
        }
    }
}
