using grindward.database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward.death_penalties
{
    public abstract class DeathPenalty : IWeighted
    {
        public static List<DeathPenalty> GetAll()
        {
            return new List<DeathPenalty>() {new LoseMoneyPenalty() , new LoseGemsPenalty() };
        }

        public abstract int GetWeight();

        public abstract String GetChatNotification();

        public abstract bool CanHappen(Character character, Bag bag);

        public abstract void Activate(Character character, Bag bag);

        public void SendMessage(Character character)
        {           
            character.CharacterUI.ShowInfoNotification(GetChatNotification());

        }
    }
}
