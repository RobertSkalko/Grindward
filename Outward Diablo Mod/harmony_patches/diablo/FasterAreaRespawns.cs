using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{
    
    [HarmonyPatch(typeof(Area), "ResetTime", MethodType.Getter)]
    public class FasterAreaRespawns
    {
        [HarmonyPostfix]
        public static void Postfix(Area __instance, ref float __result)
        {           
            if (__result > 0)
            {
                if (__instance.IsOutdoor())
                {
                    __result = __result / 2F;
                }
                else
                {
                    __result = __result / 1.5F;
                }
                
            }
        }
    }

}
