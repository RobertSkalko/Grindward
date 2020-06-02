using grindward;
using grindward.database;
using grindward.database.affixes;
using grindward.database.gear_types;
using grindward.database;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace grindward
{
    public class SuffixData : ISaveToString<SuffixData> 
    {

        String id = "";

        int percent = 0;


       public Suffix GetSuffix()
        {
            if (Registry.Suffixes.Has(id))
            {
                return Registry.Suffixes.Get(id);
            }

            return null;
        }

        public void Randomize(Item item)
        {

           GearType type =ItemUtils.GetGearType(item);

            if (type == null)
            {
                UnityEngine.Debug.Log("Gear Type is null? Aborting suffix generation.");
                return;
            }

           List<Suffix> possible = Registry.Suffixes.GetAll().Where(x => x.CanBeOnGearType(type)).ToList();

            if (possible.Count > 0)
            {
                Suffix suffix = RandomUtils.WeightedRandom(possible);

                this.id = suffix.GetId();
                this.percent = new System.Random().Next(25, 100);

                UnityEngine.Debug.Log("Affix generated succesfully");
            }

        }

        public void ApplyToItem(Equipment item)
        {
            Affix affix = GetSuffix();

            if (affix != null)
            {
                affix.GetVanillaStatMods().ForEach(x => x.ApplyToItem(percent, item));

            }
        }

       

       public SuffixData LoadFromString(string str)
        {
            try
            {
                UnityEngine.Debug.Log(str);

                String[] parts = str.Split('#');
                if (parts.Length == 2)
                {
                    this.id = parts[0];
                    this.percent = int.Parse(parts[1]);

                    UnityEngine.Debug.Log("Loaded suffix: " + id + " " + percent);

                }
            }
            catch (Exception e)
            {
                throw;
            }

            return this;
        }

        public string GetSaveString()
        {
           
            if (id == "" || percent == 0)
            {
                return "";
            }

            return id + "#" + percent;

            
        }
    }
}
