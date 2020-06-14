using grindward.ambush_penalties;
using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.harder_survival
{

    [HarmonyPatch(typeof(CampingEvent), "OnActivate")]
    public class AmbushPenaltyPatch
    { 

        static List<AmbushPenalty> PENALTIES = new List<AmbushPenalty>() { new SadistBleed(), new WitchEleVulne(), new PranksterPoison() };


        [HarmonyPostfix]
        public static void Postfix()
        {
            if (!Configs.Instance.EnableAmbushPenalties.Value)
            {
                return;
            }

          
            NetworkLevelLoader.Instance.onAllPlayersLoadingDone += Activate;                             

        }

        public static void Activate()
        {
            Log.Debug("activating ambush penalty");

            PENALTIES.RandomWeighted().Activate(CharacterUtils.GetAllPlayers());
        }
        
        
    }



 
}
