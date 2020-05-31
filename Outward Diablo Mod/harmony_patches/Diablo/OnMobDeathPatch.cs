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
  
    [HarmonyPatch(typeof(LootableOnDeath), "OnDeath")]
    public class OnMobDeathPatch
    {

        [HarmonyPrefix]
        public static void Prefix(LootableOnDeath __instance, bool __0, ref bool __state)
        {
            __state = Fields.INSTANCE.LootableOnDeath_WasAlive.GetValue(__instance);
        }

        [HarmonyPostfix]
        public static void Postfix(LootableOnDeath __instance,  ref bool __state)
        {
            if (__state != Fields.INSTANCE.LootableOnDeath_WasAlive.GetValue(__instance))
            {
                ItemContainer _container = __instance.Character.Inventory.Pouch;

                GearType type = RandomUtils.WeightedRandom(Registry.GearTypes.GetAll());

                UnityEngine.Debug.Log("random gear type gotten");

                Item randomItem = RandomUtils.RandomFromList(type.GetAllItems()); // this seems null

                UnityEngine.Debug.Log("random item gotten");

                Item generatedItem = ItemManager.Instance.GenerateItemNetwork(randomItem.ItemID);

                UnityEngine.Debug.Log("item gened");

                if (generatedItem != null)
                {
                    //generatedItem.GetComponent<DiabloItemExtension>().source = DiabloItemExtension.ItemSource.MobDrop;

                    UnityEngine.Debug.Log("The ext is there");

                    _container.AddItem(generatedItem);

                    _container.AddSilver(500);

                    UnityEngine.Debug.Log("added item to pouch");
                }
            }
            else
            {
                UnityEngine.Debug.Log("Cant gen loot anymore");
            }
         
        }
    }
}
