﻿using grindward.currency;
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
        public static int HELLSTONE_OF_WHIRLING_ID = 999323;
        public static int HELLSTONE_OF_OVERHAUL_ID = 999324;
        public static int HELLSTONE_OF_INCORPORATION_ID = 999325;
        public static int HELLSTONE_OF_ARCANA_ID = 999326;

        // Keep the names similar so they will be near each other at crafting order :)
        public Item HELLSTONE_OF_WITHDRAWAL;
        public Item HELLSTONE_OF_TEMPERING;
        public Item HELLSTONE_OF_WHIRLING;
        public Item HELLSTONE_OF_OVERHAUL;
        public Item HELLSTONE_OF_INCORPORATION;
        public Item HELLSTONE_OF_ARCANA;

        public Items() {


            HELLSTONE_OF_WITHDRAWAL = NewHellstone(HACKMANITE, HELLSTONE_OF_WITHDRAWAL_ID, "Hellstone of Withdrawal", "This gem seems to contain power to untangle that which is entangled.");
            HELLSTONE_OF_TEMPERING = NewHellstone(HACKMANITE, HELLSTONE_OF_TEMPERING_ID, "Hellstone of Tempering", "This gem contains boundless but reckless power.");
            HELLSTONE_OF_WHIRLING = NewHellstone(HACKMANITE, HELLSTONE_OF_WHIRLING_ID, "Hellstone of Whirling", "This gem seems to keep spinning.");
            HELLSTONE_OF_OVERHAUL = NewHellstone(HACKMANITE, HELLSTONE_OF_OVERHAUL_ID, "Hellstone of Overhaul", "Power to remake, into something better.");
            HELLSTONE_OF_INCORPORATION = NewHellstone(HACKMANITE, HELLSTONE_OF_INCORPORATION_ID, "Hellstone of Incorporation", "Become more, yet remain the same.");
            HELLSTONE_OF_ARCANA = NewHellstone(HACKMANITE, HELLSTONE_OF_ARCANA_ID, "Hellstone of Arcana", "Forget yourself.");

        }

        private static Item NewHellstone(int baseItemID, int newItemId, String name, String desc)
        {

            int totalWeight = CurrencyEffects.ALL[newItemId].Sum(x => x.GetWeight());

            desc += "\n";

            CurrencyEffects.ALL[newItemId].ForEach(x =>
            {
                float chance = (float) x.GetWeight() / (float) totalWeight * 100;

                desc += "\n" + chance + "% to: " + x.Get().GetDescription() + "\n";
            });

            desc += "\n Use when your desired gear is in your pouch (and no other gear there).";

            if (HELLSTONE_OF_ARCANA_ID != newItemId) // this hellstone is used on non magical items, unlike others
            {
                desc += "\n Only works on Magical items.";
            }
            else
            {
                desc += "\n Only works on Non Magical items.";
            }

            var template = new SL_Item()
            {
            Name = name,            
            Description = desc,
            Target_ItemID = baseItemID,
            New_ItemID = newItemId,
            Tags = new string[]

            {
            TagSourceManager.Valuable.TagName
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

            CustomItemVisuals.SetSpriteLink(item, sprite);

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
