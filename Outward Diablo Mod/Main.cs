using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using grindward.database;
using grindward.Reflection;
using SideLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using grindward;
using grindward.utils;

namespace grindward
{
    [BepInPlugin(ID, NAME, VERSION)]
    class Main : BaseUnityPlugin
    {
        public static bool DEBUG = true;

      
        const string ID = "com.treborx555.grindward"; 
        const string NAME = "Grindward";
        const string VERSION = "1.0";

         public static  String MODID = "grindward";

        internal void Awake()
        {          

            try
            {
                Cached.Instance = new Cached();

                Fields.INSTANCE = new Fields();
                Methods.INSTANCE = new Methods();

                Registry.Init();
                RegistryRegister.RegisterAll();

                SL.OnPacksLoaded += SL_OnPacksLoaded;

                var harmony = new Harmony(ID);
                harmony.PatchAll();

                Logger.Log(LogLevel.Message, "Treborx555: Outward Diablo Mod is done initiating.");
            }
            catch(Exception e)
            {               
                Logger.Log(LogLevel.Message, "Treborx555: Outward Diablo Mod had failed to init!");
                throw e;

            }


        

        }

        private void SL_OnPacksLoaded()
        {

            try
            {
                List<Item> correct = new List<Item>();
                List<Item> incorrect = new List<Item>();


                foreach (Item item in CustomItems.RPM_ITEM_PREFABS.Values)
                {
                    if (ItemUtils.IsGear(item, true))
                    {
                        correct.Add(item);
                    }
                    else
                    {
                        if (item is Equipment)
                        {
                            incorrect.Add(item);

                        }
                    }
                }
                Log.Debug("Items considered correct gears: ");

                foreach (Item item in correct)
                {
                    UnityEngine.Object.DontDestroyOnLoad(DiabloItemExtension.AddToItem(item));

                    Log.Debug(item.name + ": Value: " + item.Value + " Durability: " + item.MaxDurability);

                }
                Log.Debug("Items that aren't considered correct gears: ");

                foreach (Item item in incorrect)
                {
                    Log.Debug(item.name + " is an unused gear item. ID: " + item.ItemID);

                }

                Debug.Log("Finished Adding diablo item extension to all gear items.");
            }
            catch
            {
                Debug.Log("FAILED TO LOAD GRINDWARD!!!");
                throw;
            }

        }
    }
}
