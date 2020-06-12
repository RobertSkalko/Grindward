using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward.death_penalties
{
    class LoseMoneyPenalty : DeathPenalty
    {
        static int MIN_LOSS = 50;
        static int MAX_LOSS = 150;

        static float LOSS_MULTI_CIERZO = 0.5F;

        public override void Activate(Character character, Bag bag)
        {
            int loss = UnityEngine.Random.Range(MIN_LOSS, MAX_LOSS);

            // if in cierzo multi todo

            if (character.Inventory.HasABag)
            {
                character.Inventory.RemoveMoney(loss);
                character.CharacterUI.ShowInfoNotification(GetChatNotification());
            }
            else if (bag)
            {
                bag.Container.RemoveSilver(loss);
                character.CharacterUI.ShowInfoNotification(GetChatNotification());
            }
            else
            {
                Log.Print("Failed to activate death penalty even when the previous check returned it can be possible???");
            }

        }

        public override bool CanHappen(Character character, Bag bag)
        {
            if (character.Inventory.HasABag)
            {
                return character.Inventory.AvailableMoney > MIN_LOSS;
            }
            else
            {               
                return bag.ContainedSilver > MIN_LOSS;
            }
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
