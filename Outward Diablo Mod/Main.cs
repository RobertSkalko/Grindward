using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using grindward.database;
using grindward.Reflection;
using SideLoader;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace grindward
{
    [BepInPlugin(ID, NAME, VERSION)]
    class Main : BaseUnityPlugin
    {
        const string ID = "com.treborx555.grindward"; 
        const string NAME = "Grindward";
        const string VERSION = "1.0";

         public static  String MODID = "grindward";

        internal void Awake()
        {
          

            try
            {
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

            foreach (Item item in CustomItems.RPM_ITEM_PREFABS.Values)
            {
                if (ItemUtils.IsGear(item))
                {
                    UnityEngine.Object.DontDestroyOnLoad(DiabloItemExtension.AddToItem(item));
                    //Debug.Log("Added diablo item extension to: " + item.name);
                }
            }

            Debug.Log("Finished Adding diablo item extension to all gear items.");
        }
    }
}
