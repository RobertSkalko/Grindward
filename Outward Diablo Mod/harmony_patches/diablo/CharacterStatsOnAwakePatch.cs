using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{

    [HarmonyPatch(typeof(CharacterStats), "OnAwake")]
    public class CharacterStatsOnAwakePatch
    {
        [HarmonyPostfix]
        public static void Postfix(CharacterStats __instance)
        {          
            Stat mana = Fields.INSTANCE.CharStats_ManaUse.GetValue(__instance);

            mana.RangeLimit = Stat.RangeLimitType.Min;
            mana.MinRange = 10;
        }
    }

    [HarmonyPatch(typeof(CharacterStats), "UpdateEquipmentStats")]
    public class CharacterStatsOnCalcualtePatch
    {
        [HarmonyPostfix]
        public static void Postfix(CharacterStats __instance)
        {         
            float[] resstats = Fields.INSTANCE.CharStats_DmgResistance.GetValue(__instance);

            for (int i =0; i< resstats.Length; i++)
            {
                if (resstats[i] > 0.9F)
                {
                    resstats[i] = 0.9F;                                      

                }
            }
        }

    }


}
