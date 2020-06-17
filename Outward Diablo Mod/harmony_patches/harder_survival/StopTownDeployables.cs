using grindward.ambush_penalties;
using grindward.utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static AreaManager;

namespace grindward.harmony_patches.harder_survival
{
    [HarmonyPatch(typeof(Deployable), "TryDeploying")]
   public class StopTownDeployables

    {

        public static bool IsNearChest(Character character)
        {
            
           foreach (TreasureChest chest in Resources.FindObjectsOfTypeAll<TreasureChest>())
            {
                if (chest.SpecialType == ItemContainer.SpecialContainerTypes.Stash)
                {
                    float distance = Vector3.Distance(character.CenterPosition, chest.PreviousPos);

                    if (distance < 75)
                    {
                        //Log.Debug("is near chest");

                        return true;
                    }
                    else
                    {
                        //Log.Debug(" not close enough to chest");
                    }
                }
            }

            return false;

        }

    

        [HarmonyPrefix]
        public static bool Prefix(Deployable __instance)
        {
            if (!Configs.Instance.EnableStopTownDeployables.Value)
            {
                return true;
            }
            Character c = __instance.Item.OwnerCharacter;        
                     
            if (AreaManager.Instance.GetIsCurrentAreaTownOrCity())
            {
                if (!IsNearChest(c))
                {
                    c.CharacterUI.ShowInfoNotification("The Guards won't allow you to place stuff outside your home.");
                    return false;
                }
            }

            return true;

        }
    }
}
