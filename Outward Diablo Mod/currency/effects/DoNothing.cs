using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency.effects
{
    class DoNothing : ItemChanger
    {
        public override void ChangeItem(Equipment item)
        {
           
        }
        public override string GetChatNotification()
        {
            return "Nothing appears to happen.";
        }

        public override string GetDescription()
        {
            return "Does nothing.";
        }
    }
}
