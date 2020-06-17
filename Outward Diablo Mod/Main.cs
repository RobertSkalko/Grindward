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
using grindward.database.tiers.bases;
using grindward.database.registers;
using System.Reflection;
using System.Linq;
using NodeCanvas.Framework;
using NodeCanvas.BehaviourTrees;
using BepInEx.Configuration;
using UnityEngine.SceneManagement;

namespace grindward
{
    [BepInPlugin(ID, NAME, VERSION)]
    class Main : BaseUnityPlugin
    {
        public static bool DEBUG = true;

       public static Items Items;

        public static Main Instance = null;
      
        const string ID = "grindward"; 
        const string NAME = "Grindward";
        const string VERSION = "1.0";
        public static  String MODID = "grindward";       

        internal void Awake()
        {    

            Instance = this;
            Configs.Instance = new Configs();             

            SL.OnSceneLoaded += OnSceneChange;

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
            catch (Exception e)
            {
                Logger.Log(LogLevel.Message, "Treborx555: Outward Diablo Mod had failed to init!");
                Console.Write(e.ToString());
                Crash();
            }

        }


        
        
        //String areaid = "";
        /*
        void Update()        {



            // TODO, figuring out how defeat scenarios work
            if (DefeatScenariosManager.Instance != null && DefeatScenariosManager.Instance.Container != null)
            {
                if (AreaManager.Instance != null && AreaManager.Instance.CurrentArea != null)
                {

                    String current = areaid;
                    areaid = AreaManager.Instance.CurrentArea.ID + "";

                    if (areaid != current)
                    {
                        var cont = DefeatScenariosManager.Instance.Container;

                        DictionaryExt<string, DefeatScenario> dict = (DictionaryExt<string, DefeatScenario>)typeof(DefeatScenariosContainer).GetField("m_events", ReflectionUtils.flags).GetValue(cont);

                        Log.Print("Area: " + AreaManager.Instance.CurrentArea.GetName());

                        foreach (DefeatScenario scen in dict.Values)
                        {
                            Log.Print(scen.name + " " + scen.ID + " " + scen.GetType().ToString());
                        }
                    }

                }
            }
        }
        */

        void Crash()
        {
            Application.Quit();
        }


        private void OnSceneChange()
        {
            AddRecipesToShops();

            AISquadManager.Instance.SpawnTime = 30; // 60 is default
        }

        void AddRecipesToShops()
        {

            Log.Debug("finding npcs");

            List<GameObject> list = Resources.FindObjectsOfTypeAll<GameObject>().Where(x => x.name.Contains("CaravanTrader")).ToList();

            foreach (GameObject obj in list)
            {
                Log.Debug("found npc");

                if (obj.GetComponentInChildren<MerchantPouch>(true) is MerchantPouch pouch)
                {
                    foreach (RecipeItem recipe in Recipes.recipeItems)
                    {
                        if (!recipe.GetIsLearned(CharacterManager.Instance.GetWorldHostCharacter())) { // only spawn if host doesnt know
                            if (!pouch.ContainsOfSameID(recipe.ItemID))
                            {
                                Item gen = ItemManager.Instance.GenerateItemNetwork(recipe.ItemID);
                                gen.transform.parent = pouch.transform;

                                Log.Debug("added recipe item");
                            }
                        } 
                    }
                }
            }
        }




        private void DoTests()
        {
            Log.Debug("Starting tests");

            Weapon wep = (Weapon)ItemManager.Instance.GenerateItemNetwork(GearTypes.Instance.oneHandWeapon.GetAllItems()[0].ItemID);
            Armor armor = (Armor)ItemManager.Instance.GenerateItemNetwork(GearTypes.Instance.boots.GetAllItems()[0].ItemID);

            wep.ProcessInit();
            armor.ProcessInit();

            if (wep == null || armor == null)
            {
            Log.Debug("Error, Test items are null!!");
            }            
                           
            if (wep.Stats == null || armor.Stats == null)
            {
            Log.Debug("Error, Test item stats are null!!");
            }

            Log.Debug("Setup test items");


            foreach (VanillaStat stat in Registry.VanillaStats.GetAll())
            {
                if (stat.StatType == VanillaStat.Type.GearStat)
                {
                    stat.TestIfWorks(wep);
                    stat.TestIfWorks(armor);
                }
                else if (stat.StatType == VanillaStat.Type.ArmorStat)
                {
                    stat.TestIfWorks(armor);
                }
                else if (stat.StatType == VanillaStat.Type.WeaponStat)
                {
                    stat.TestIfWorks(wep);

                }
            }

            Log.Debug("Tests finished");

        }


        private void SL_OnPacksLoaded()
        {

            try
            {

                Items = new Items();
                Log.Print("Items created");


                List<Item> correct = new List<Item>();
                List<Item> incorrect = new List<Item>();


                foreach (Item item in CustomItems.RPM_ITEM_PREFABS.Values)
                {
                    if (ItemUtils.IsValidGear(item, true))
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

                    Log.Debug("ID:" + item.ItemID + " Name:"  + item.Name + " : Value: " + item.Value + " Durability: " + item.MaxDurability);

                }
                Log.Debug("Items that aren't considered correct gears: ");

                foreach (Item item in incorrect)
                {
                    Log.Debug(item.name + " is an unused gear item. ID: " + item.ItemID);

                }

                Debug.Log("Finished Adding diablo item extension to all gear items.");


                /*
                Tag ingredient = TagSourceManager.GetCraftingIngredient(Recipe.CraftingType.Survival);
                correct.Where(x=> !x.HasTag(ingredient)).ToList().ForEach(x => x.Tags.Add(ingredient));
                Items.GetHellStones().ForEach(x => x.Get().Tags.Add(ingredient));
                // adds ingredient tag so they can be added as ingredients
                */

                Recipes.Init();

                DoTests();

            }
            catch(Exception e)
            {
                Debug.Log("FAILED TO LOAD GRINDWARD!!!");
                Console.Write(e.ToString());               
                Crash();
            }

        }
    }
}
