using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class TurnMagical : ItemChanger
    {
        public override void ChangeItem(Equipment item)
        {
            DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();
            ext.isMagical = true;

        }
        public override string GetChatNotification()
        {
            return "The item has become Magical!";
        }

        public override string GetDescription()
        {
            return "Makes the item Magical.";
        }
    }
}
