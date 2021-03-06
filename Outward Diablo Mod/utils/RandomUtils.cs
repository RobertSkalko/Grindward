﻿using grindward.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace grindward.utils
{
    public class RandomUtils
    {
        static System.Random ran = new System.Random(Guid.NewGuid().GetHashCode());

        public static bool Roll(float chance)
        {
            return chance >= UnityEngine.Random.Range(0F, 100F);

        }
        public static T WeightedRandom<T>(IList<T> coll) where T : IWeighted
        {
           
            return WeightedRandom(coll, ran.NextDouble());
        }

        public static T RandomFromList<T>(IList<T> list)
        {
            if (list == null || list.Count ==0)
            {
                return default(T);
            }

            int random = ran.Next(0, list.Count - 1);
            return list[random];

        }
        private static T WeightedRandom<T>(IList<T> lootTable, double nextDouble) where T : IWeighted
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

        private static int Total<T>(IList<T> list) where T : IWeighted
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
