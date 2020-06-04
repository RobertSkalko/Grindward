using grindward.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class Weighted<T> : IWeighted
    {
        private T obj;
        private int weight;

        public Weighted(T obj, int weight)
        {
            this.obj = obj;
            this.weight = weight;
        }

        public T Get()
        {
            return obj;
        }

        public int GetWeight()
        {
            return weight;
        }
    }
}
