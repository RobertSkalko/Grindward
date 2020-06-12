using grindward.database;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public static class ExtensionMethods
    {
        public static Bag FindNearestBackpack(this Character character)
        {
            return character.Inventory.Equipment.LastOwnedBag;
            

            foreach (Item item in Fields.INSTANCE.ItemManager_WorldItems.GetValue(ItemManager.Instance).Values)
            {
                if (item is Bag && !item.IsEquipped)
                {
                    float distance = Vector3.Distance(character.CenterPosition, item.PreviousPos);

                    if (distance < 250)
                    {
                        return (Bag)item;
                    }

                }
            }

            return null;
        }
        public static T RandomWeighted<T>(this IList<T> list) where T : IWeighted
        {
            return RandomUtils.WeightedRandom(list);
        }


        public static bool HasSameBuyAndSellValue(this Item item)
        {
            if (item.ItemID == ItemIDs.SILVER_COIN || item.ItemID == ItemIDs.GOLD_BAR)
            {
                return true;
            }

            return item.HasTag(TagSourceManager.Valuable);

        }
    }
}
