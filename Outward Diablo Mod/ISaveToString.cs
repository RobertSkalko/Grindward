using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public interface ISaveToString<T>
    {
         String GetSaveString();

        T LoadFromString(String str);


    }
}
