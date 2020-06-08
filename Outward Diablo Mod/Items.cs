using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class Items
    {
        public static string CURRENCY_TAG = "craft_currency";

        Item HELLSTONE_OF_WITHDRAWAL;
        public Items() {
            HELLSTONE_OF_WITHDRAWAL = CustomItems.CreateCustomItem(6200130, 999321, "Hellstone of Withdrawal");
            SL_Item helper =SL_Item.ParseItemToTemplate(HELLSTONE_OF_WITHDRAWAL);
            helper.Description = "Changes item's affixes randomly. Sometimes removes them.";
            helper.New_ItemID = 999321;
            helper.Tags.Add(CURRENCY_TAG);
            helper.Name = "Hellstone of Withdrawal";
            helper.ApplyTemplateToItem();
        }

        public List<Weighted<Item>> GetHellStones()
        {
            return new List<Weighted<Item>>() { 
                new Weighted<Item>(HELLSTONE_OF_WITHDRAWAL,1000) 
            };
        }

    }
}
