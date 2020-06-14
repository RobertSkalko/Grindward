using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.easier_survival
{

    [HarmonyPatch(typeof(Skill), "ConsumeRequiredItems")]
    public class ChanceToNotConsumeSigilStones
    {
        [HarmonyPrefix]
        public static bool Prefix(Skill __instance)
        {           
            if (RandomUtils.Roll(50)){
                if (__instance.RequiredItems != null)
                {
                    Item item = __instance.RequiredItems[0].Item;
                    int id = item.ItemID;

                    if (id == ItemIDs.COLD_STONE || id == ItemIDs.FIRE_STONE)
                    {
                        return false;
                    }
                }
                
            }

            return true;

        }
    }
}
