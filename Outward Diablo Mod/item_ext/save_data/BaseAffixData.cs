﻿using grindward.database.gear_types;
using grindward.item_ext.save_data;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public abstract class BaseAffixData<A> : ISaveToString , IApplyableItemStats where A : Affix
    {

        protected String id = "";

        int percent = 0;

        bool addedStats = false;


        public abstract A GetAffix();
        public abstract List<A> GetAll();


        public void ClearAffix(Equipment item)
        {
            this.ChangeItemStats(item, StatChangeType.REMOVE);

            this.percent = 0;
            this.id = "";

        }

        public void RandomizeNumbers(Equipment item)
        {

            ChangeItemStats((Equipment)item, StatChangeType.REMOVE);

            percent = RollPercent(); 
            
            ChangeItemStats((Equipment)item, StatChangeType.ADD);

        }

        public void Randomize(Item item)
        {

            Log.Debug("Randomizing item's affix: " + item.Name);


            ChangeItemStats((Equipment)item, StatChangeType.REMOVE);


            GearType type = ItemUtils.GetGearType(item);

            if (type == null)
            {
                UnityEngine.Debug.Log("Gear Type is null? Aborting suffix generation.");
                return;
            }

            List<A> possible = GetAll().Where(x=> x.CanBeOnGearType(type)).ToList();

            if (possible.Count > 0)
            {
                A affix = RandomUtils.WeightedRandom(possible);

                this.id = affix.GetId();
                this.percent = RollPercent();

                //UnityEngine.Debug.Log("Affix generated succesfully");
            }

            ChangeItemStats((Equipment)item, StatChangeType.ADD);

        }

        private int RollPercent()
        {
            return UnityEngine.Random.Range(25, 100);
        }





        public string GetSaveString()
        {

            if (id == "" || percent == 0)
            {
                return "";
            }

            return id + "#" + percent;

        }

        public void LoadFromString(string str)
        {

           try
                {
                    Log.Debug(str);

                    String[] parts = str.Split('#');
                    if (parts.Length == 2)
                    {
                        this.id = parts[0];
                        this.percent = int.Parse(parts[1]);

                        //UnityEngine.Debug.Log("Loaded Affix: " + id + " " + percent);

                    }
                }
                catch (Exception e)
                {
                    throw;
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

            Affix affix = GetAffix();

            if (affix != null)
            {
                affix.GetVanillaStatMods().ForEach(x => x.ApplyToItem(percent, item, type));
             
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
