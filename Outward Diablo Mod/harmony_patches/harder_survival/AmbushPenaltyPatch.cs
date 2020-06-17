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
        public static void Postfix(CampingEvent __instance)
        {
            if (!Configs.Instance.EnableAmbushPenalties.Value)
            {
                return;
            }

            if (Fields.INSTANCE.CampingEvent_squadtospawn.GetValue(__instance))
            {
                if (RandomUtils.Roll(50))
                {
                    NetworkLevelLoader.Instance.onAllPlayersLoadingDone += Activate;
                }
            }
            else
            {
                Log.Debug("Not an ambush camp event");
            }

        }

        public static void Activate()
        {
            Log.Debug("activating ambush penalty");

            PENALTIES.RandomWeighted().Activate(CharacterUtils.GetAllPlayers());
        }
        
        
    }



 
}
