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

namespace grindward
{
    class DiabloItemExtension : ItemExtension
    {


        static string ID = Main.MODID + ":random_stats";

        public SuffixData suffix = new SuffixData();
        public PrefixData prefix = new PrefixData();

        public RandomStatsData randomStats = new RandomStatsData();

        public ItemSource source = ItemSource.None;

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
                Debug.Log(item.name + " already has a " + ID + " component!");
                return extension;
            }

            DiabloItemExtension ext = item.gameObject.AddComponent<DiabloItemExtension>();
            ext.Savable = true;
            ext.m_item = item;
            return ext;
        }

        public override void InitFromItem()
        {                                 
            if (init)
            {
                return; 
            }

            this.randomStats = new RandomStatsData();
            this.randomStats.Randomize((Equipment)this.Item);

            if (source == ItemSource.ChestLoot || source == ItemSource.MobDrop) 
            {   
                
                this.suffix = new SuffixData();
                suffix.Randomize(this.Item);

                this.prefix = new PrefixData();
                prefix.Randomize(this.Item);

                this.ApplyStats();

                this.init = true;                
            }

        }

        public void ApplyStats()
        {
            randomStats.ApplyToItem((Equipment)Item);

            if (HasSuffix())
            {
                suffix.ApplyToItem((Equipment)Item);
            }
            if (HasPrefix())
            {
                prefix.ApplyToItem((Equipment)Item);
            }
            
        }

        public override void OnReceiveNetworkSync(string[] str)
        {

            try
            {
                Debug.Log(str.Length);
                Debug.Log(str);


                if (str.Length == Enum.GetNames(typeof(SyncOrder)).Length) 
                    {
                        int boolInt = 0;
                        int.TryParse(str[(int)SyncOrder.Init], out boolInt);
                        this.init = boolInt == 1 ? true : false;


                    String sourcesave = str[(int)SyncOrder.Source];
                    if (sourcesave.Length > 0)
                    {
                        this.source = (ItemSource)Enum.Parse(typeof(SyncOrder), sourcesave);
                    }

                    foreach (SyncOrder sync in GetSavables())
                        {

                        String savestr = str[(int)sync];
                        Log.Debug("Loading " + sync.ToString() + savestr);
                        Get(sync).LoadFromString(savestr);

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
                        
            String initsave = init.ToInt().ToString();

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
            list[(int)SyncOrder.Source] = ((int)source)+ "";
            list[(int)SyncOrder.Prefix] = prefixsave;
            list[(int)SyncOrder.RandomStats] = randomsave;

            return String.Join(";", list);

        }

        public enum SyncOrder
        {
            Init = 0,
            Suffix =  1,
            Source = 2,
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
