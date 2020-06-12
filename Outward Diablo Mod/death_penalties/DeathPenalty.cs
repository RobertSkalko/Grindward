using grindward.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.death_penalties
{
    public abstract class DeathPenalty : IWeighted
    {
        public static List<DeathPenalty> GetAll()
        {

            return new List<DeathPenalty>() {new LoseMoneyPenalty() };
        }

        public abstract int GetWeight();

        public abstract String GetChatNotification();

        public abstract bool CanHappen(Character character, Bag bag);

        public abstract void Activate(Character character, Bag bag);
    }
}
