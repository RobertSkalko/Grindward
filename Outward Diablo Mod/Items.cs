using grindward.currency;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward
{
    public class Items
    {
        public static string CURRENCY_TAG_ID = "craft_currency";
        public static Tag CURRENCY_TAG = new Tag("craft_currency");
        static int HACKMANITE_ID = 6200130;


        public static int HELLSTONE_OF_WITHDRAWAL_ID = 999321;      
        public Item HELLSTONE_OF_WITHDRAWAL;
       

        public Items() {
                     
           
            HELLSTONE_OF_WITHDRAWAL = NewHellstone(HACKMANITE_ID, HELLSTONE_OF_WITHDRAWAL_ID, "Hellstone of Withdrawal", "This gem seems to contain power to untangle that which is entangled." );

        }

        private static Item NewHellstone(int baseItemID, int newItemId, String name, String desc)
        {
            CurrencyEffects.ALL[baseItemID].ForEach(x => desc += "\n" + x.GetDescription() + "\n");

            Item item = CustomItems.CreateCustomItem(newItemId, newItemId, "Hellstone of Withdrawal");

            SL_Item helper = SL_Item.ParseItemToTemplate(item);
            helper.Name = name;
            helper.Description = desc;
            helper.New_ItemID = newItemId;
            helper.Tags.Add(CURRENCY_TAG_ID);
            helper.IsUsable = true;
            helper.ApplyTemplateToItem();

            var effects = item.transform.Find("Effects");
            if (effects == null)
            {
                // If the item doesn't have "Effects", just add it.
                effects = new GameObject("Effects").transform;
                effects.transform.parent = item.transform;
                // If you didn't use CreateCustomItem, you'd need to call DontDestroyOnLoad(gaberries.gameObject);
            }
            CurrencyEffectComponent eff = effects.gameObject.AddComponent<CurrencyEffectComponent>();
            UnityEngine.Object.DontDestroyOnLoad(eff);
          

            return item;

        }


        public List<Weighted<Item>> GetHellStones()
        {
            return new List<Weighted<Item>>() { 
                new Weighted<Item>(HELLSTONE_OF_WITHDRAWAL,1000) 
            };
        }

    }
}
