using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace outward_diablo.HarmonyPatches
{
    [HarmonyPatch(typeof(Item), "GetBuyValue")]
    public class BuyFromMerchantPatch
    {
        // make shop sell prices higher.

        [HarmonyPostfix]
        public static void Postfix(Item __instance, ref int __result)
        {
            if (__instance.IsEquippable)
            {
                __result = (int)(3D * __result);
            }
            else if(__instance.IsIngredient)
            {
                __result = (int)(2D * __result);
            }
          

        }
    }
}
