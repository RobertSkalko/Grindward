using grindward.death_penalties;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{   
        [HarmonyPatch(typeof(DefeatPlayerSpawn), "SpawnPlayerChar")]
        class OnDeathSpawnPatch
        {
            [HarmonyPrefix]
            public static void Prefix(DefeatPlayerSpawn __instance, Character ___0)
            {
            Bag bag = ___0.FindNearestBackpack();

            DeathPenalty.GetAll().Where(x => x.CanHappen(___0, bag)).ToList().RandomWeighted().Activate(___0, bag);

             }   

    }
}
