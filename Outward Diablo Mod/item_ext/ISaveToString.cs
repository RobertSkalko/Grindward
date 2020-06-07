using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public interface ISaveToString
    {
         String GetSaveString();

        void LoadFromString(String str);


    }
}
