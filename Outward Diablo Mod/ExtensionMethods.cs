using grindward.database;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public static class ExtensionMethods
    {
        public static T RandomWeighted<T>(this IList<T> list) where T : IWeighted
        {
            return RandomUtils.WeightedRandom(list);
        }
    }
}
