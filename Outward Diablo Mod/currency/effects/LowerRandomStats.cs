using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class LowerRandomStats : ItemChanger
    {   
       

        public override void ChangeItem(Equipment item)
        {
           
                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();
                            
                ext.randomStats.AddToAllPercents(item,-5);

            
        }

        public override string GetDescription()
        {
            return "Lowers the random stats.";
        }
    }
}
