using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.utils
{
   public class Log
    {

        static String PREFIX = "[Grindward]: ";
        public static  void Print(String str)
        {
            Console.WriteLine(PREFIX + str);
        }

        public static void Debug(String str)
        {
            if (Main.DEBUG)
            {
                Console.WriteLine(PREFIX + str);
            }
        }
    }
}
