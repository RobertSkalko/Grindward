using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{
    [HarmonyPatch(typeof(SelfFilledItemContainer), "GenerateContents")]
    class ChestLootPatch
    {
        [HarmonyPostfix]
        public static void Postfix(SelfFilledItemContainer __instance)
        {
            if (__instance is TreasureChest)
            {
                if (PhotonNetwork.isNonMasterClientInRoom)
                {
                    return;
                }

                LootUtils.TryGenerateLoot(__instance, null, DiabloItemExtension.ItemSource.ChestLoot);
            }
        }
    }
}