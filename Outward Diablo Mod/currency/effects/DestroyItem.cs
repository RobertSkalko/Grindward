using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class DestroyItem : ItemChanger
    {
      

        public override void ChangeItem(Equipment item)
        {
           
                ItemManager.Instance.DestroyItem(item.UID);
            
        }

        public override string GetChatNotification()
        {
            return "Unfortunately, the item crumbled.";
        }

        public override string GetDescription()
        {
            return "Destroys the item.";
        }
    }
}
