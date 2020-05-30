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

            if (true) // todo chances
            {   
                
                this.suffix = new SuffixData();
                suffix.Randomize(this.Item);
                suffix.ApplyToItem((Equipment)Item);


                this.init = true;
                
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
                        this.suffix = new SuffixData();
                        suffix.LoadFromString(suffixsave);
                    }
                }

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

                        
            return String.Join(";", list);

        }

        public enum SyncOrder
        {
            Init = 0,
            Suffix =  1,
        }

    }
}
