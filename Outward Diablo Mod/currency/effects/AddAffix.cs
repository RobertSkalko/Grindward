using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency.effects
{
    class AddAffix : ItemChanger
    {
        public override void ChangeItem(Equipment item)
        {
            DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

            if (!ext.HasSuffix())
            {
                ext.suffix.Randomize(item);
                return;
            }
            if (!ext.HasPrefix())
            {
                ext.prefix.Randomize(item);
                return;
            }
        }
        public override string GetChatNotification()
        {
            return "An affix has appeared.";
        }

        public override string GetDescription()
        {
            return "Gives one affix to item.";
        }
    }
}
