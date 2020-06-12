using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward.death_penalties
{
    class LoseGemsPenalty : DeathPenalty
    {
        static int MIN_LOSS = 1;
        static int MAX_LOSS = 6;

        static float LOSS_MULTI_CIERZO = 0.5F;

        public override void Activate(Character character, Bag bag)
        {
            int loss = UnityEngine.Random.Range(MIN_LOSS, MAX_LOSS);

            if (AreaManager.Instance.CurrentArea.IsChersonese())
            {
                loss = (int)(loss * LOSS_MULTI_CIERZO);
            }

            List<Item> items= new List<Item>();

            if (character.Inventory.HasABag)
            {
                items.AddRange(character.Inventory.GetOwnedItems(TagSourceManager.Valuable));               
            }
            if (bag)
            {
                items.AddRange(bag.Container.GetItemsFromTag(TagSourceManager.Valuable));                
            }

            character.CharacterUI.ShowInfoNotification(GetChatNotification());

            for (int i =0; i< items.Count(); i++)
            {
                if (loss > 0)
                {
                    items[i].RemoveQuantity(1);
                    loss--;
                }
                else
                {
                    return;
                }
            }

        }

        public override bool CanHappen(Character character, Bag bag)
        {
            List<Item> items = new List<Item>();

            if (character.Inventory.HasABag)
            {
                items.AddRange(character.Inventory.GetOwnedItems(TagSourceManager.Valuable));               
            }
            if (bag)
            {
                items.AddRange(bag.Container.GetItemsFromTag(TagSourceManager.Valuable));              
            }

            return items.Count() > MIN_LOSS;

        }

        public override string GetChatNotification()
        {
            return "You notice some gems are missing from your inventory.";
        }

        public override int GetWeight()
        {
            return 250;
        }
    }
}
