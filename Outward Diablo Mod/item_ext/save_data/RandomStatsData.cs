using grindward.database;
using grindward.database.registers;
using grindward.database.tiers.bases;
using grindward.item_ext.save_data;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward.save_data
{
    public class RandomStatsData : ISaveToString , IApplyableItemStats
    {
        List<int> percents = new List<int>();

        bool addedStats = false;



        public void Randomize(Equipment item)
        {
            ChangeItemStats((Equipment)item, StatChangeType.REMOVE);

            Equipment def = (Equipment)Cached.GetDefaultItemPrefab(item);

            percents.Clear();

            foreach(VanillaStat stat in VanillaStats.Instance.GetAllStatsOrderedByIndex())
            {
                float val = stat.GetStat(def);

                if (val != 0)
                {
                    percents.Add(RollPercent(item));                  
                }
            }

            ChangeItemStats((Equipment)item, StatChangeType.ADD);
        }

        public void AddToAllPercents(Equipment item, int amount)
        {
            ChangeItemStats(item, StatChangeType.REMOVE);

            int i = 0;
            foreach (int percent in percents.ToList())
            {
                int modified = percent + amount;

                modified = Mathf.Clamp(modified, 0, Tier.MAX_RANDOM_PERCENT);

                percents[i] = modified;

                i++;
            }

            ChangeItemStats(item, StatChangeType.ADD);
        }

        int RollPercent(Equipment item)
        {
            Tier tier = Tier.GetTierOfItem(item);

            return (int) UnityEngine.Random.Range(tier.GetRandomStatsPercents().min, tier.GetRandomStatsPercents().max);
        }             

        public string GetSaveString()
        {
            return String.Join("#", percents);
        }

        public void LoadFromString(string str)
        {
           foreach ( String s in str.Split('#'))
            {
                int perc = -1;
                
                int.TryParse(s, out perc);

                if (perc > -1)
                {
                    percents.Add(perc);
                }
                else
                {                   
                    Log.Print("Random stat failed to load: " + str );                   
                }
            }
        }

        public void ChangeItemStats(Equipment item, StatChangeType type)
        {

            if (type == StatChangeType.ADD && addedStats)
            {
                return;
            }
            if (type == StatChangeType.REMOVE && !addedStats)
            {              
                return;
            }

            Equipment def = (Equipment)Cached.GetDefaultItemPrefab(item);

            int index = 0;

            var stats = VanillaStats.Instance.GetAllStatsItemHasOrderedByIndex(item);

            while (percents.Count < stats.Count)
            {
                percents.Add(RollPercent(item));
            }

            foreach (VanillaStat stat in stats)
            {
                float defaultVal = stat.GetStat(def);

                if (defaultVal != 0)
                {
                    float currentVal = stat.GetStat(item);

                    float shouldBe = percents[index] * defaultVal / 100F;

                    int diff = (int)(shouldBe - defaultVal); // we want pretty numbers

                    if (type == StatChangeType.REMOVE)
                    {
                        diff *= -1;
                    }

                    stat.SetStat(item, currentVal + diff);
                }

                index++;
            }

            if (type == StatChangeType.ADD)
            {
                addedStats = true;
            }
            if (type == StatChangeType.REMOVE)
            {
                addedStats = false;
            }

        }


    }
}
