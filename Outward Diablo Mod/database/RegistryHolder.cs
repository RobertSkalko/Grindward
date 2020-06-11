using grindward.database.affixes;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.database
{
    public class RegistryHolder<T>  where T: RegistryEntry
    {     

        Dictionary<String, T> map = new Dictionary<string, T>();


        public T Get(String id)
        {
            if (map.ContainsKey(id))
            {
                return map[id];
            }
            return default(T);
        }

        public T Register(T entry)
        {
            map.Add(entry.GetId(),entry);

            return entry;
        }
             

        public bool Has(String id)
        {
            return map.ContainsKey(id);

        }


        public List<T> GetAll()
        {
            return new List<T>(map.Values);
        }
    }
}
