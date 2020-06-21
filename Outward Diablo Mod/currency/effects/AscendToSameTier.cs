using grindward.database.tiers.bases;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency.effects
{
    class AscendToSameTier : ItemChanger
    {
        public override void ChangeItem(Equipment item)
        {

            Tier tier = Tier.GetTierOfItem(item);
            
            List<Item> possible = Cached.Instance.ITEM_GEAR_TYPES[item.ItemID].GetAllItemsOfTier(tier);

            Item newitem = ItemManager.Instance.GenerateItemNetwork(RandomUtils.RandomFromList(possible).ItemID);

            DiabloItemExtension ext = newitem.GetComponent<DiabloItemExtension>();
            ext.isMagical = true;

            newitem.ChangeParent(item.ParentContainer.transform);

            ItemManager.Instance.DestroyItem(item.UID);


        }
        public override string GetChatNotification()
        {
            return "This is not the same item anymore, it seems completely new.";
        }

        public override string GetDescription()
        {
            return "Destroys the item, but turns it into a random same tier item of same type.";
        }
    }
}
