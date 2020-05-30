using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using outward_diablo.database;
using outward_diablo.Reflection;
using SideLoader;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace outward_diablo
{
    [BepInPlugin(ID, NAME, VERSION)]
    class Main : BaseUnityPlugin
    {
        const string ID = "com.treborx555.outward_diablo_mod"; 
        const string NAME = "Outward Diablo Mod";
        const string VERSION = "1.0";

         public static  String MODID = "outward_diablo";

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
            using (Dictionary<string, Item>.ValueCollection.Enumerator enumerator = (typeof(ResourcesPrefabManager).GetField("ITEM_PREFABS", ReflectionUtils.flags).GetValue(null) as Dictionary<string, Item>).Values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Item item = enumerator.Current;
                    if (ItemUtils.IsGear(item))
                    {                     
                        UnityEngine.Object.DontDestroyOnLoad(DiabloItemExtension.AddToItem(item));
                        //Debug.Log("Added diablo item extension to: " + item.name);
                    }
                }
            }

            Debug.Log("Finished Adding diablo item extension to all gear items.");
        }
    }
}
