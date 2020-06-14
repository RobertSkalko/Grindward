using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.harder_survival
{

    [HarmonyPatch(typeof(CampingEvent), "OnActivate")]
    public class FoodEtcPenaltyOnAmbush
    {
        static int divideBy = 5;

        [HarmonyPostfix]
        public static void Postfix()
        {
            if (!Configs.Instance.EnableAmbushPenalties.Value)
            {
                return;
            }

            Log.Debug("activating ambush penalty");

            foreach (Character player in CharacterUtils.GetAllPlayers())
            {
                player.PlayerStats.Food -= player.PlayerStats.MaxFood / divideBy;
                player.PlayerStats.Drink -= player.PlayerStats.MaxDrink / divideBy;
                player.PlayerStats.Sleep -= player.PlayerStats.MaxSleep / (divideBy * 2);
            }

        }
    }

 
}
