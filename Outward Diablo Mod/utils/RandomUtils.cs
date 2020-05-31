using OutwardDiabloMod.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutwardDiabloMod.utils
{
    class RandomUtils
    {
        

        public static T WeightedRandom<T>(List<T> coll) where T : IWeighted
        {
            return WeightedRandom(coll, new Random().NextDouble());
        }

        public static T RandomFromList<T>(List<T> list)
        {
            if (list == null || list.Count ==0)
            {
                return default(T);
            }

            int random = new Random().Next(0, list.Count - 1);
            return list[random];

        }
        private static T WeightedRandom<T>(List<T> lootTable, double nextDouble) where T : IWeighted
        {

            double value = Total(lootTable) * nextDouble;
            double weight = 0;

            foreach (T item in lootTable)
            {
                weight += item.GetWeight();
                if (value < weight)
                    return (T)item;
            }

            return default(T);
        }

        private static int Total<T>(List<T> list) where T : IWeighted
        {

            int total = 0;

            foreach (IWeighted w in list)
            {
                total += w.GetWeight();
            }
            return total;

        }

    }
}
