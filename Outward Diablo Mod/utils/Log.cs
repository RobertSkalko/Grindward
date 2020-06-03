using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.utils
{
    class Log
    {
        public static  void Print(String str)
        {
            Console.Write(str);
        }

        public static void Debug(String str)
        {
            if (Main.DEBUG)
            {
                Console.Write(str);
            }
        }
    }
}
