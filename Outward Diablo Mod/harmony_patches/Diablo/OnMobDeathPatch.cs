using HarmonyLib;
using Microsoft.Win32;
using outward_diablo;
using outward_diablo.database;
using outward_diablo.database.gear_types;
using OutwardDiabloMod.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;
using Registry = outward_diablo.database.Registry;

namespace OutwardDiabloMod.harmony_patches.Diablo
{
  
    [HarmonyPatch(typeof(LootableOnDeath), "Start")]
    public class OnMobDeathPatch
    {
        [HarmonyPostfix]
        public static void Postfix(LootableOnDeath __instance)
        {

            if (__instance.gameObject.GetComponent<MyDropable>() == null)
            {

                MyDropable drop = __instance.gameObject.AddComponent<MyDropable>();
                drop.transform.ResetLocal(true);
                drop.name = "diablo_mod_random_loot";
                drop.SetUID(__instance.Character.UID + "_diablo_loot_");
                drop.UpdateSelf = false;

                Dropable[] list = Fields.INSTANCE.LootableOnDeath_lootDroppers.GetValue(__instance);

                List<DropTable> tables = Fields.INSTANCE.Dropable_lootables.GetValue(drop);
                MyItemDropper mydropper = drop.gameObject.AddComponent<MyItemDropper>();
                tables.Add(mydropper);
                list.AddItem(drop);

                Fields.INSTANCE.Dropable_lootables.SetValue(drop, tables);
                Fields.INSTANCE.LootableOnDeath_lootDroppers.SetValue(__instance, list);

                UnityEngine.Debug.Log("Added lootable");

            }
        }
    }
}
