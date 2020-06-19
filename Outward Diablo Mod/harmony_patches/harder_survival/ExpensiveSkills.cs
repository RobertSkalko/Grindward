using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.harder_survival
{   

    [HarmonyPatch(typeof(SkillSlot), "RequiredMoney", MethodType.Getter)]
    public class ExpensiveSkills
    {
        [HarmonyPostfix]
        public static void Postfix(SkillSlot __instance, ref int __result)
        {
            if (!Configs.Instance.EnableExpensiveSkillCosts.Value)
            {
                return;
            }

            if (__result < 200)
            {
                __result = (int)(2D * __result);
            }
            else
            {

            }          

        }
    }
}
