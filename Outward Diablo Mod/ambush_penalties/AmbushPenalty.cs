using grindward.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.ambush_penalties
{
    public abstract class AmbushPenalty : IWeighted
    {
        public static String BLEED = "Bleeding";
        public static String SLOW = "Slow Down";
        public static String FOOD_POISONING = "Food Poisoned";
        public static String INDIGESTION = "Indigestion1";
        public static String POISONED = "Poisoned";
        public static String DIZZY = "Dizzy";
        public static String ELE_VULNERABILITY = "Elemental Vulnerability";

        public abstract string GetNotification();

        public  void Activate(List<Character> players)
        {
            foreach (Character p in players)
            {
                act(p);
                p.CharacterUI.ShowInfoNotification(GetNotification());
            }
        }

        public abstract void act(Character player);        

        public abstract int GetWeight();
    }
}
