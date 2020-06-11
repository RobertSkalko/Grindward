﻿using grindward.utils;
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

        public static bool IsInTown()
        {
            var area = AreaManager.Instance.CurrentArea;

            List<AreaEnum> towns = new List<AreaEnum>() { AreaEnum.CierzoVillage, AreaEnum.Levant, AreaEnum.Monsoon, AreaEnum.Berg };

            foreach (AreaEnum areaenum in towns)
            {
                Area current = AreaManager.Instance.GetArea(areaenum);

                if (current == area)
                {
                    //Log.Debug("Is in town");
                    return true;
                }
            }
            //Log.Debug("Is not in town");

            return false;

        }

        [HarmonyPrefix]
        public static bool Prefix(Deployable __instance)
        {
            Character character = __instance.Item.OwnerCharacter;

            if (IsInTown())
            {
                if (!IsNearChest(character))
                {
                    return false;
                }
            }

            return true;


        }
    }
}