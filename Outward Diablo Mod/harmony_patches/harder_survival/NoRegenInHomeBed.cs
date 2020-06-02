using HarmonyLib;
using grindward.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.HarmonyPatches.harder_survival
{

    /// <summary>
    /// Need to do 2 things. Make inns and beds not regain hunger and thirst, AND make them actually spend it.
    /// </summary>

    [HarmonyPatch(typeof(CharacterResting), "GetFoodRestored")]
    public class NoHungerSleepRegen
    {
        [HarmonyPostfix]
        public static void Postfix(ref float __result)
        {
            __result = 0;

        }
    }
    [HarmonyPatch(typeof(CharacterResting), "GetDrinkRestored")]
    public class NoThirstSleepRegen
    {
        [HarmonyPostfix]
        public static void Postfix(ref float __result)
        {
            __result = 0;

        }
    }
    [HarmonyPatch(typeof(CharacterResting), "GetDrinkConsumptionModifier")]
    public class HungerSleep
    {
        [HarmonyPostfix]
        public static void Postfix(CharacterResting __instance, ref float __result)
        {
            __result = Methods.INSTANCE.CharacterResting_GetStat.Call(__instance, new object[] { CharacterResting.CompilationType.Average, CharacterResting.CompiledStat.DrinkConsumption });
                        
        }
    }
    [HarmonyPatch(typeof(CharacterResting), "GetFoodConsumptionModifier")]
    public class ThirstSleep
    {
        [HarmonyPostfix]
        public static void Postfix(CharacterResting __instance, ref float __result)
        {
            __result = Methods.INSTANCE.CharacterResting_GetStat.Call(__instance, new object[] { CharacterResting.CompilationType.Average, CharacterResting.CompiledStat.FoodConsumption });

        }
    }
}
