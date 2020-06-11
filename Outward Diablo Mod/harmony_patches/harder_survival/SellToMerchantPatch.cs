using HarmonyLib;
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
            if (ItemUtils.IsValidGear(__instance))
            {
                __result = (int)(0.5D * __result);
            }    

        }
    }
}
