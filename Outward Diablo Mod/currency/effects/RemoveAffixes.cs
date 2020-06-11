using grindward.database.affixes;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class RemoveAffixes : ItemChanger
    {
       
        public RemoveAffixes()
        {           
        }

        public override void ChangeItem(Equipment item)
        {
           
                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

                if (ext.HasSuffix())
                {
                    ext.suffix.ClearAffix(item);
                }
                if (ext.HasPrefix())
                {
                    ext.prefix.ClearAffix(item);
                }
            
        }
        public override string GetChatNotification()
        {
            return "The item was cleared of its affixes.";
        }

        public override string GetDescription()
        {
            return "Removes All affixes.";
        }
    }
}
