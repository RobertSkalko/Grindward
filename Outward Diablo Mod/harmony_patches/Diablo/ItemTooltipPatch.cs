using HarmonyLib;
using grindward.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using grindward.database.tiers.bases;
using grindward.database.affixes;

namespace grindward.harmony_patches.diablo
{
    [HarmonyPatch(typeof(ItemDetailsDisplay), "RefreshDetails")]
    public class ItemTooltipPatch
    {
       
        [HarmonyPostfix]
        public static void Postfix(ItemDetailsDisplay __instance)
        {
           
          

            if (__instance == null)
            {            
                Console.WriteLine("This shouldn't be null.");

                return;

            }

            if (__instance.LastItemDisplay == null)
            {
                return;
            }

            if (__instance.LastItemDisplay.RefItem is Equipment item)
            {
                if (!ItemUtils.IsValidGear(item))
                {
                    return;
                }

                int hp = (int)item.Stats.MaxHealthBonus;
                if (hp != 0)
                {
                    AddStatTooltip(__instance, "Bonus Health", hp + "");
                }


                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();
                              
                if (ext != null)
                {
                    Tier tier = Tier.GetTierOfItem(item);

                    String tiername = tier.GetItemTierName();

                    if (ext.IsValidRandomDrop())
                    {
                        tiername = "Magical " + tiername;
                    }

                    AddTooltip(__instance, tiername);
                }
            }
        }

        private static void AddStatTooltip(ItemDetailsDisplay __instance, String stat, string val)
        {
            List<ItemDetailRowDisplay> tooltip = Fields.INSTANCE.TOOLTIP.GetValue(__instance);

            ItemDetailRowDisplay statRow = Methods.INSTANCE.ItemDetailsDisplay_GetRow.Call(__instance, new object[] { tooltip.Count });
                                  
            statRow.SetInfo(stat, val);

            ItemDetailRowDisplay durability = tooltip[tooltip.Count - 2];

            //tooltip[tooltip.Count - 2] = statRow;
            //tooltip[tooltip.Count - 1] = durability;

            Fields.INSTANCE.TOOLTIP.SetValue(__instance, tooltip);
        }
        private static void AddTooltip(ItemDetailsDisplay __instance, String val)
        {
            List<ItemDetailRowDisplay> tooltip = Fields.INSTANCE.TOOLTIP.GetValue(__instance);

            ItemDetailRowDisplay statRow = Methods.INSTANCE.ItemDetailsDisplay_GetRow.Call(__instance, new object[] { tooltip.Count });

            statRow.SetInfo("", val);          

            Fields.INSTANCE.TOOLTIP.SetValue(__instance, tooltip);
        }


    }

   
}
