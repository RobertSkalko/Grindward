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
        public static void Prefix(LootableOnDeath __instance, ref bool __0)
        {
            bool loadedead = __0;
            bool wasalive = Fields.INSTANCE.LootableOnDeath_WasAlive.GetValue(__instance);

            if ((!PhotonNetwork.isNonMasterClientInRoom && !__instance.Character.Alive)
                || (PhotonNetwork.isNonMasterClientInRoom && __instance.Character.IsDead && wasalive))
            {

                if (!loadedead && !PhotonNetwork.isNonMasterClientInRoom)
                {

                    ItemContainer _container = __instance.Character.Inventory.Pouch;

                    GearType type = RandomUtils.WeightedRandom(Registry.GearTypes.GetAll());

                    UnityEngine.Debug.Log("random gear type gotten");

                    Item randomItem = RandomUtils.RandomFromList(type.GetAllItems());

                    UnityEngine.Debug.Log("random item gotten");

                    Item generatedItem = ItemManager.Instance.GenerateItemNetwork(randomItem.ItemID);

                    if (generatedItem != null)
                    {
                        UnityEngine.Debug.Log("item gened");

                        generatedItem.GetComponent<DiabloItemExtension>().source = DiabloItemExtension.ItemSource.MobDrop;

                        UnityEngine.Debug.Log("The ext is there");

                        generatedItem.ChangeParent(_container.transform); // container.additem() bugs out, use this instead. DONT ASK WHY

                        _container.AddSilver(500);

                        UnityEngine.Debug.Log("added item to pouch");

                    }

                }
            }
        } 
    }
}
