using grindward.database.affixes;
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

            return map[id];
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
