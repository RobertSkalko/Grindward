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

        Item HELLSTONE_OF_WITHDRAWAL;
        public Items() {

            HELLSTONE_OF_WITHDRAWAL = CustomItems.CreateCustomItem(6200130, 999321, "Hellstone of Withdrawal");
                                    
            SL_Item helper =SL_Item.ParseItemToTemplate(HELLSTONE_OF_WITHDRAWAL);
            helper.Name = "Hellstone of Withdrawal";
            helper.Description = "Changes item's affixes randomly. Sometimes removes them.";
            helper.New_ItemID = 999321;                 
            helper.Tags.Add(CURRENCY_TAG_ID);           
            helper.IsUsable = true;
            helper.ApplyTemplateToItem();

            var effects = HELLSTONE_OF_WITHDRAWAL.transform.Find("Effects");
            if (effects == null)
            {
                // If the item doesn't have "Effects", just add it.
                effects = new GameObject("Effects").transform;
                effects.transform.parent = HELLSTONE_OF_WITHDRAWAL.transform;
                // If you didn't use CreateCustomItem, you'd need to call DontDestroyOnLoad(gaberries.gameObject);
            }
            CurrencyEffect eff= effects.gameObject.AddComponent<CurrencyEffect>();
            UnityEngine.Object.DontDestroyOnLoad(eff);
            //eff.RegisterToSynchronizer();

        }

        public void CopyAll<T>(T source, T target)
        {
            var type = typeof(T);
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
            }
            foreach (var sourceField in type.GetFields())
            {
                var targetField = type.GetField(sourceField.Name);
                targetField.SetValue(target, sourceField.GetValue(source));
            }
        }

        public List<Weighted<Item>> GetHellStones()
        {
            return new List<Weighted<Item>>() { 
                new Weighted<Item>(HELLSTONE_OF_WITHDRAWAL,1000) 
            };
        }

    }
}
