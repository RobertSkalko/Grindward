﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.harder_survival
{

    [HarmonyPatch(typeof(Item), "GetSellValue")]
    public class SellToMerchantPatch
    {
        // make players earn less money by selling gear

        [HarmonyPostfix]
        public static void Postfix(Item __instance, ref int __result)
        {
            if (!Configs.Instance.EnableMerchantPrices.Value)
            {
                return;
            }

            int saved = __result;

            if (__instance.HasSameBuyAndSellValue())
            {
                return;
            }

            if (__instance.IsFood)
            {
                __result = (int)(0.6D * __result);
            }
            else if (ItemUtils.IsValidGear(__instance))
            {
                __result = (int)(0.25D * __result);
            }
            else
            {
                __result = (int)(0.5D * __result);
            }

            if (saved > 0 && __result < 1)
            {
                __result = 1; // make 1 minimum sell price
            }
        }
    }
}
