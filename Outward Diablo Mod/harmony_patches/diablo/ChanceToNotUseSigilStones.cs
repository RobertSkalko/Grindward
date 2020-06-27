using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{
    class ChanceToNotUseSigilStones
    {
        [HarmonyPatch(typeof(Skill), "ConsumeRequiredItems")]
        public class EquipmentNamePatch
        {
            [HarmonyPrefix]
            public static bool Prefix(Skill __instance)
            {
                try
                {
                    if (!Configs.Instance.EnableChanceToNotUseSigilStones.Value)
                    {
                        return true;
                    }

                    if (__instance.RequiredItems.Any(x => x.Item.ItemID == ItemIDs.COLD_STONE || x.Item.ItemID == ItemIDs.FIRE_STONE))
                    {
                        if (RandomUtils.Roll(66))
                        {
                            return false;
                        }
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }

                return true;                
            }
        }
    }
}
