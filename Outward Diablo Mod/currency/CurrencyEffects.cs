using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    public class CurrencyEffects
    {       

        public static  Dictionary<int, List<ItemChanger>> ALL = new Dictionary<int, List<ItemChanger>>()
        {
            {  Items.HELLSTONE_OF_WITHDRAWAL_ID, new List<ItemChanger>() { new RerollAffixes(), new ChanceToRemoveAffixes(5)} }
        };
        
    }
}
