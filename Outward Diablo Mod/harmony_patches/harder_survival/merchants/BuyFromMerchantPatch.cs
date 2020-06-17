using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.harder_survival
{
    [HarmonyPatch(typeof(Item), "GetBuyValue")]
    public class BuyFromMerchantPatch
    {
        // make shop sell prices higher.

        [HarmonyPostfix]
         public  static void Postfix(Item __instance, ref int __result)
        {
            if (!Configs.Instance.EnableMerchantPrices.Value)
            {
                return;
            }

            if (__instance.HasSameBuyAndSellValue())
            {
                return;
            }

            if (__instance.IsEquippable)
            {
                __result = (int)(2D * __result);
            }
            else if (__instance.IsIngredient)
            {
                __result = (int)(1.75D * __result);
            }
            else
            {
                __result = (int)(1.5 * __result);
            }
        }
    }
}
