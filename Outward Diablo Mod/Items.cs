using grindward.currency;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static grindward.ItemIDs;
using UnityEngine;

namespace grindward
{
    public class Items
    {
        public static string CURRENCY_TAG_ID = "craft_currency";
        public static Tag CURRENCY_TAG = new Tag("craft_currency");

        public static int HELLSTONE_OF_WITHDRAWAL_ID = 999321;
        public static int HELLSTONE_OF_TEMPERING_ID = 999322;

        public Item HELLSTONE_OF_WITHDRAWAL;
        public Item HELLSTONE_OF_TEMPERING;

        public Items() {


            HELLSTONE_OF_WITHDRAWAL = NewHellstone(HACKMANITE, HELLSTONE_OF_WITHDRAWAL_ID, "Hellstone of Withdrawal", "This gem seems to contain power to untangle that which is entangled.");
            HELLSTONE_OF_TEMPERING = NewHellstone(HACKMANITE, HELLSTONE_OF_TEMPERING_ID, "Hellstone of Tempering", "This gem can be used to temper gear.");

        }

        private static Item NewHellstone(int baseItemID, int newItemId, String name, String desc)
        {
            desc += "\n";

            CurrencyEffects.ALL[newItemId].ForEach(x => desc += "\n" + x.GetDescription() + "\n");

            desc += "\n Use when your desired gear is in your pouch (and no other gear there).";
                      
            var template = new SL_Item()
            {
            Name = name,            
            Description = desc,
            Target_ItemID = baseItemID,
            New_ItemID = newItemId,
            Tags = new List<string>()

            {
            CURRENCY_TAG_ID,
            },
            IsUsable = true
            };

            var item = CustomItems.CreateCustomItem(template);

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

            var png = CustomTextures.LoadTexture(@"BepInEx\plugins\Grindward\Icons\" + newItemId + ".png", false, false);
            var sprite = CustomTextures.CreateSprite(png, CustomTextures.SpriteBorderTypes.ItemIcon);
            At.SetValue(sprite, typeof(Item), item, "m_itemIcon");

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
