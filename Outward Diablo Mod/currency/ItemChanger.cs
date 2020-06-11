using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    public abstract class ItemChanger
    {
        public abstract void ChangeItem(Equipment item);

        public abstract String GetDescription();

        public abstract String GetChatNotification();


    }
}
