using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;

namespace grindward.death_penalties
{
    class LoseMoneyPenalty : DeathPenalty
    {
        static int MIN_LOSS = 100;
        static int MAX_LOSS = 250;

        static float LOSS_MULTI_CIERZO = 0.5F;

        private static int GetTotalMoney(Character character, Bag bag)
        {

            int silver = character.Inventory.Pouch.GetContainedItems().Where(x => x.ItemID == ItemIDs.GOLD_BAR).Sum(x=> +100);

            if (bag)
            {
                silver += bag.Container.GetContainedItems().Where(x => x.ItemID == ItemIDs.GOLD_BAR).Sum(x => +100);
            }

            silver += character.Inventory.ContainedSilver;

            return silver;

        }

        private static void RemoveMoney(int money, Character character, Bag bag)
        {

            int golds = money / 100;

            for (int i =0; i< golds; i++)
            {
                List<Item> goldItems = character.Inventory.GetOwnedItems(ItemIDs.GOLD_BAR);

                if (bag)
                {
                    goldItems.AddRange(bag.Container.GetContainedItems().Where(x => x.ItemID == ItemIDs.GOLD_BAR));
                }

                Log.Debug("Found " + goldItems.Count() + " gold bar items");

                if (goldItems.Count() > 0)
                {
                    if (money > 100)
                    {                        
                        goldItems[0].RemoveQuantity(1);
                        money -= 100;
                    }
                    else
                    {
                        return;
                    }
                }               

            }

            if (money > 0)
            {
                character.Inventory.RemoveMoney(money);
            }

            if (money > 0 && bag)
            {
                bag.Container.RemoveSilver(money);
            }

        }            

        public override void Activate(Character character, Bag bag)
        {          

            int loss = UnityEngine.Random.Range(MIN_LOSS, MAX_LOSS);

            if (AreaManager.Instance.CurrentArea.IsChersonese())
            {
                loss = (int) (loss *  LOSS_MULTI_CIERZO);
            }


            RemoveMoney(loss, character, bag);
            this.SendMessage(character);

        }

        public override bool CanHappen(Character character, Bag bag)
        {
            return GetTotalMoney(character, bag) > MIN_LOSS;
           
        }

        public override string GetChatNotification()
        {
            return "You notice some money is missing from your inventory.";
        }

        public override int GetWeight()
        {
            return 1000;
        }
    }
}
