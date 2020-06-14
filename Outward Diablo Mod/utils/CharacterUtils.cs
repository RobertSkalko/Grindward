using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward.utils
{
    public class CharacterUtils
    {       
        public static List<Character> GetAllPlayers()
        {
            var list = new List<Character>();

            foreach (String id in Fields.INSTANCE.CharacterManager_Playerchars.GetValue(CharacterManager.Instance).Keys)
            {
                Character c = CharacterManager.Instance.GetCharacterFromPlayer(id);

                if (!c)
                {
                    Log.Print("Character is null!");
                }

                list.Add(c);
            }

            return list;
        }

    }
}
