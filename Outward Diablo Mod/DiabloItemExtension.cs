using outward_diablo.database.affixes;
using OutwardDiabloMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace outward_diablo
{
    class DiabloItemExtension : ItemExtension
    {


        static string ID = Main.MODID + ":random_stats";

        public SuffixData suffix = null;

        public ItemSource source = ItemSource.None;

        public bool init = false;

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

            if (source == ItemSource.ChestLoot || source == ItemSource.MobDrop) 
            {   
                
                this.suffix = new SuffixData();
                suffix.Randomize(this.Item);

                this.ApplyStats();

                this.init = true;                
            }

        }

        public void ApplyStats()
        {
            if (suffix != null)
            {
                suffix.ApplyToItem((Equipment)Item);
            }

        }

        public override void OnReceiveNetworkSync(string[] str)
        {

            try
            {
                Debug.Log(str.Length);
                Debug.Log(str);


                if (str.Length > 0)
                {
                    int boolInt = 0;
                    int.TryParse(str[(int)SyncOrder.Init], out boolInt);
                    this.init = boolInt == 1 ? true : false;
                }

                if (str.Length > 1)
                {
                    String suffixsave = str[(int)SyncOrder.Suffix];
                    if (suffixsave.Length > 0)
                    {
                        Debug.Log("Loading suffix: " + suffixsave);

                        this.suffix = new SuffixData();
                        suffix.LoadFromString(suffixsave);
                    }
                }

                if (str.Length > 2)
                {
                    String sourcesave = str[(int)SyncOrder.Source];
                    if (sourcesave.Length > 0)
                    {
                        this.source = (ItemSource)Enum.Parse(typeof(SyncOrder), sourcesave);
                    }
                }


                ApplyStats();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public override string ToNetworkInfo()
        {

            String[] list = Enumerable.Repeat("", Enum.GetValues(typeof(SyncOrder)).Length).ToArray();
                        
            String initsave = init.ToInt().ToString();

            String suffixsave = "";
            if (suffix != null)
            {
               suffixsave =  suffix.GetSaveString();
            }

            list[(int)SyncOrder.Init] = initsave;
            list[(int)SyncOrder.Suffix] = suffixsave;
            list[(int)SyncOrder.Source] = ((int)source)+ "";
           

            return String.Join(";", list);

        }

        public enum SyncOrder
        {
            Init = 0,
            Suffix =  1,
            Source = 2,
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
