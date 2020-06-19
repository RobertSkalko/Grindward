using grindward.database.affixes;
using grindward;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ExitGames.Client.Photon;
using MapMagic;
using grindward.save_data;
using grindward.utils;
using grindward.item_ext.save_data;

namespace grindward
{
    public class DiabloItemExtension : ItemExtension
    {


        static string ID = Main.MODID + ":random_stats";

        public SuffixData suffix = new SuffixData();
        public PrefixData prefix = new PrefixData();

        public RandomStatsData randomStats = new RandomStatsData();

        public bool isMagical = false;

        public bool init = false;

        public bool HasSuffix()
        {
            return suffix != null && suffix.GetAffix() != null;
       }
        public bool HasPrefix()
        {
            return prefix != null && prefix.GetAffix() != null;
        }
              

        public ISaveToString Get(SyncOrder sync)
        {

            if (sync == SyncOrder.Prefix)
            {
                return prefix;
            }
            if (sync == SyncOrder.Suffix)
            {
                return suffix;
            }
            if (sync == SyncOrder.RandomStats)
            {
                return randomStats;
            }

            return null;
        }



        public List<SyncOrder> GetSavables()
        {
            return new List<SyncOrder>() { SyncOrder.Prefix, SyncOrder.Suffix, SyncOrder.RandomStats };
        }

        public static DiabloItemExtension AddToItem(Item item)
        {
            if (item.GetExtension(ID) is DiabloItemExtension extension)
            {
                 Log.Print(item.name + " already has a " + ID + " component!");
                return extension;
            }

            DiabloItemExtension ext = item.gameObject.AddComponent<DiabloItemExtension>();
            ext.Savable = true;
            ext.m_item = item;
            return ext;
        }

        static int AFFIX_CHANCE = 25;

        public override void InitFromItem()
        {

            Log.Debug(Item.Name + " Checking if should init");

            if (init)
            {
                return; 
            }
            Log.Debug(Item.Name + " Initializing");


            this.randomStats = new RandomStatsData();
            this.randomStats.Randomize((Equipment)this.Item);

            if (isMagical) 
            {
                if (RandomUtils.Roll(AFFIX_CHANCE))
                {
                    this.suffix = new SuffixData();
                    suffix.Randomize(this.Item);
                }
                if (RandomUtils.Roll(AFFIX_CHANCE))
                {
                    this.prefix = new PrefixData();
                    prefix.Randomize(this.Item);
                }                   

            }

            this.ApplyStats();

            this.init = true;
        }

        private void ClearAll(Equipment item)
        {
            randomStats.Clear(item);

            if (HasPrefix())
            {
                prefix.ClearAffix(item);
            }
            if (HasSuffix())
            {
                suffix.ClearAffix(item);
            }


        }


        public bool IsValidRandomDrop()
        {
            return isMagical;
        }

        public void ApplyStats()
        {
            randomStats.ChangeItemStats((Equipment)Item, StatChangeType.ADD);

            if (HasSuffix())
            {
                suffix.ChangeItemStats((Equipment)Item, StatChangeType.ADD);
            }
            if (HasPrefix())
            {
                prefix.ChangeItemStats((Equipment)Item, StatChangeType.ADD);
            }
            
        }

        public override void OnReceiveNetworkSync(string[] str)
        {

            if (this.Item is Equipment == false)
            {
                Log.Print("Not equipment? Aborting diablo item ext sync");
                return;
            }

            try
            {

                 ClearAll((Equipment)this.Item);
               
                 Log.Debug(this.Item.Name + ": " + String.Join(";",str));

                if (str.Length == Enum.GetNames(typeof(SyncOrder)).Length) 
                    {
                       
                    string initstr = str[(int)SyncOrder.Init];

                    if (initstr == "t")
                    {
                        this.init = true;
                    }
                                       
                    if (this.init == false && str[(int)SyncOrder.RandomStats].Length > 0)
                    {
                        Log.Print("Item says it didn't INIT, but random stats are initalized already???");
                        Log.Print("Init save string: " + initstr);
                    }

                    String sourcesave = str[(int)SyncOrder.IsMagical];
                    if (sourcesave.Length > 0)
                    {
                        if (sourcesave == "t")
                        {
                            this.isMagical = true;
                        }                        
                    }

                    foreach (SyncOrder sync in GetSavables())
                        {

                        String savestr = str[(int)sync];
                        if (savestr.Length > 0)
                        {
                            Get(sync).LoadFromString(savestr);
                            Log.Debug("Loading item ext part: " + sync.ToString() + " " + savestr);
                        }
                        else
                        {
                            //Log.Debug("Item ext part is empty: " + sync.ToString());
                        } 

                        }                  
                    
                    }
                    else
                    {

                         Log.Print("Error, item didn't get enogh sync strings!");

                    }

            }
            catch (Exception e)
            {
                Debug.Log("Error updating item from network packet");
                throw;
            }

            try
            {
                ApplyStats();
            }
            catch
            {
                Debug.Log("Error applying stats");
                throw;
            }
        }

        public override string ToNetworkInfo()
        {

            String[] list = Enumerable.Repeat("", Enum.GetValues(typeof(SyncOrder)).Length).ToArray();

            String initsave = init ? "t" : "f";

            String suffixsave = "";
            if (HasSuffix())
            {
               suffixsave =  suffix.GetSaveString();
            }

            String prefixsave = "";
            if (HasPrefix())
            {
                prefixsave = prefix.GetSaveString();
            }

            String randomsave = this.randomStats.GetSaveString();

            list[(int)SyncOrder.Init] = initsave;
            list[(int)SyncOrder.Suffix] = suffixsave;
            list[(int)SyncOrder.IsMagical] = isMagical ? "t" : "f";
            list[(int)SyncOrder.Prefix] = prefixsave;
            list[(int)SyncOrder.RandomStats] = randomsave;

            return String.Join(";", list);

        }

        public enum SyncOrder
        {
            Init = 0,
            Suffix =  1,
            IsMagical = 2,
            Prefix = 3,
            RandomStats = 4,
        }

        public enum ItemSource
        {
            MobDrop,
            ChestLoot,
            Crafting, 
            Shop,
            Quest,
            None
        }

    }
}
