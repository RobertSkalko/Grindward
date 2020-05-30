using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.Reflection
{
   public class Methods
    {
        public static Methods INSTANCE= null;


        public SafeMethod<ItemDetailsDisplay, ItemDetailRowDisplay> ItemDetailsDisplay_GetRow = new SafeMethod<ItemDetailsDisplay, ItemDetailRowDisplay>("GetRow");
        public SafeMethod<CharacterResting, float> CharacterResting_GetStat = new SafeMethod<CharacterResting, float>("GetStat");

    }
}
