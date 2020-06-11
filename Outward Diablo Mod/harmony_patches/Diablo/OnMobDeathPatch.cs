using HarmonyLib;
using Microsoft.Win32;
using grindward;
using grindward.database;
using grindward.database.gear_types;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;
using Registry = grindward.database.Registry;
using grindward.database.tiers.bases;

namespace grindward.harmony_patches.diablo
{

    [HarmonyPatch(typeof(LootableOnDeath), "OnDeath")]
    public class OnMobDeathPatch
    {
        // this needs to be checked after updates. Any slight error and loot will either INFINITELY drop, or NEVER. 
        private static bool ShouldGenLoot(LootableOnDeath __instance, ref bool __0)
        {

            bool loadedead = __0;
            bool wasalive = Fields.INSTANCE.LootableOnDeath_WasAlive.GetValue(__instance);

            if ((!PhotonNetwork.isNonMasterClientInRoom && !__instance.Character.Alive)
                || (PhotonNetwork.isNonMasterClientInRoom && __instance.Character.IsDead && wasalive))
            {
                if (!loadedead && !PhotonNetwork.isNonMasterClientInRoom)
                {
                    return true;
                }

            }
            return false;
        }


        

        [HarmonyPrefix]
        public static void Prefix(LootableOnDeath __instance, ref bool __0)
        {
            if (!ShouldGenLoot(__instance,ref __0))
            {
                return;
            }

           ItemContainer container = __instance.Character.Inventory.Pouch;

           LootUtils.GenerateLoot(container, __instance.Character, DiabloItemExtension.ItemSource.MobDrop);

        }
    }
}
