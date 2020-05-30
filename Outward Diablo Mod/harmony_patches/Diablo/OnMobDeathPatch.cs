using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace OutwardDiabloMod.harmony_patches.Diablo
{
  
    [HarmonyPatch(typeof(LootableOnDeath), "OnDeath")]
    public class OnMobDeathPatch
    {
        [HarmonyPostfix]
        public static void Postfix(LootableOnDeath __instance)
        {
            UnityEngine.Debug.Log("on death");

            if (__instance.Character.IsAI)
            {
                ItemContainer pouch = __instance.Character.Inventory.Pouch;

               // Item test = ItemManager.Instance.GenerateItemNetwork(2100110);

                //pouch.AddItem(test);
                //pouch.AddSilver(500);
               
                //UnityEngine.Debug.Log("added item to pouch");


            }

        }
    }
}
