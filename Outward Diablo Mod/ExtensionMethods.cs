using grindward.database;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static AreaManager;

namespace grindward
{
    public static class ExtensionMethods
    {

        public static void AddStatusEffect(this Character c, string effectid)
        {
            var eff = ResourcesPrefabManager.Instance.GetStatusEffectPrefab(effectid);

            if (!eff)
            {
                Log.Print("getting Effect returns null");
            }

            Log.Debug("Effect name: "+ eff.name + " id: " + eff.IdentifierName);
                     
            c.StatusEffectMngr.AddStatusEffect(eff, c, (Transform)null);        

            Log.Debug("Player has effect: " + c.StatusEffectMngr.HasStatusEffect(eff.EffectFamily));
           
        }


        static List<AreaEnum> towns = new List<AreaEnum>() { AreaEnum.CierzoVillage, AreaEnum.Levant, AreaEnum.Monsoon, AreaEnum.Berg };
        static List<AreaEnum> outdoors = new List<AreaEnum>() { AreaEnum.CierzoOutside, AreaEnum.Abrassar, AreaEnum.HallowedMarsh, AreaEnum.Emercar, AreaEnum.AntiqueField };
        public static bool IsOutdoor(this Area area)
        {
            foreach (AreaEnum areaenum in outdoors)
            {
                Area current = AreaManager.Instance.GetArea(areaenum);
                
                if (current == area)
                {                  
                    return true;
                }
            }            

            return false;

        }

        public static bool IsChersonese(this Area area)
        {
            return AreaManager.AreaFamilies[0].FamilyKeywords.Any(x => area.SceneName.Contains(x));
        }

      
        public static Bag FindNearestBackpack(this Character character)
        {
            return character.Inventory.Equipment.LastOwnedBag;   
        }

        public static T RandomWeighted<T>(this IList<T> list) where T : IWeighted
        {
            return RandomUtils.WeightedRandom(list);
        }

        public static bool HasSameBuyAndSellValue(this Item item)
        {
            if (item.ItemID == ItemIDs.SILVER_COIN || item.ItemID == ItemIDs.GOLD_BAR)
            {
                return true;
            }

            return item.HasTag(TagSourceManager.Valuable);

        }
    }
}
