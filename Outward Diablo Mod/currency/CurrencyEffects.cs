using grindward.currency.effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    public class CurrencyEffects
    {       

        public static  Dictionary<int, List<Weighted<ItemChanger>>> ALL = new Dictionary<int, List<Weighted<ItemChanger>>>()
        {
            {  Items.HELLSTONE_OF_WITHDRAWAL_ID, new List<Weighted<ItemChanger>>() {
                new Weighted<ItemChanger>(new RerollAffixes(),95),
                new Weighted<ItemChanger>(new RemoveAffixes(),5),
            }
            },
            {  Items.HELLSTONE_OF_TEMPERING_ID, new List<Weighted<ItemChanger>>() {
                new Weighted<ItemChanger>(new IncreaseRandomStats(5),90),
                new Weighted<ItemChanger>(new DestroyItem(),10),
            }
            },
            {  Items.HELLSTONE_OF_WHIRLING_ID, new List<Weighted<ItemChanger>>() {
                new Weighted<ItemChanger>(new RerollAllNumbers(),100)
            }
            },
            {  Items.HELLSTONE_OF_OVERHAUL_ID, new List<Weighted<ItemChanger>>() {
                new Weighted<ItemChanger>(new AscendToHigherTier(),100)
            }
            },
            {  Items.HELLSTONE_OF_INCORPORATION_ID, new List<Weighted<ItemChanger>>() {
                new Weighted<ItemChanger>(new AddAffix(),75),
                new Weighted<ItemChanger>(new DestroyItem(),25),
            } 
            }
};
        
    }
}
