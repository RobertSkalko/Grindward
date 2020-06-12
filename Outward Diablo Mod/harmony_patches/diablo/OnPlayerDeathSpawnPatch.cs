using grindward.death_penalties;
using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{   
       [HarmonyPatch(typeof(DefeatPlayerSpawn), "SpawnPlayerChar")]
       public class OnPlayerDeathSpawnPatch
        {
            [HarmonyPrefix]
            public static void Prefix(DefeatPlayerSpawn __instance, Character __0)
            {
            Bag bag = __0.FindNearestBackpack();

            if (!bag)
            {
                Log.Debug("Can't find last backpack??");
            }

            var list = DeathPenalty.GetAll().Where(x => x.CanHappen(__0, bag)).ToList();
            
            if (list.Count() > 0)
            {
                list.RandomWeighted().Activate(__0, bag);
            }
            else
            {
                new LoseMoneyPenalty().Activate(__0, bag);
            }                                

           }   

    }
}
