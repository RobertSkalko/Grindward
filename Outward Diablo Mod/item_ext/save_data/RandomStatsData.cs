﻿using grindward.database;
using grindward.database.registers;
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

            foreach(VanillaStat stat in VanillaStats.Instance.GetAllStatsOrderedByIndex())
            {
                float val = stat.GetStat(def);

                if (val != 0)
                {
                    percents.Add(RollPercent());
                }
            }

            ChangeItemStats((Equipment)item, StatChangeType.ADD);
        }

        int RollPercent()
        {
            return UnityEngine.Random.Range(50, 100);
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
                    percents.Clear();
                    Log.Print("Random stats failed to load: " + str);
                }
            }
        }

        public void ChangeItemStats(Equipment item, StatChangeType type)
        {

            if (type == StatChangeType.ADD && addedStats)
            {
                return;
            }
           

            Equipment def = (Equipment)Cached.GetDefaultItemPrefab(item);

            int index = 0;

            var stats = VanillaStats.Instance.GetAllStatsItemHasOrderedByIndex(item);

            while (percents.Count < stats.Count)
            {
                percents.Add(RollPercent());
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
