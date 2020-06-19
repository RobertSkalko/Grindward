using grindward.utils;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static grindward.ItemIDs;
using static SideLoader.SL_Recipe;

namespace grindward
{
    public class Recipes
    {
      
        public static void Init()
        {
            Create(Main.Items.HELLSTONE_OF_WITHDRAWAL, new List<int>() { HACKMANITE, OCCULT_REMAINS, CRYSTAL_POWDER, SMALL_SAPPHIRE }, 8887771);
            Create(Main.Items.HELLSTONE_OF_TEMPERING, new List<int>() { LARGE_EMERALD, GOLD_LICH_MECHANISM, CRYSTAL_POWDER, OBSIDIAN_SHARD }, 8887772);
            Create(Main.Items.HELLSTONE_OF_WHIRLING, new List<int>() { MEDIUM_RUBY, POWER_COIL, FIRE_STONE, GHOST_EYE }, 8887773);
            Create(Main.Items.HELLSTONE_OF_OVERHAUL, new List<int>() { MANA_STONE, BLUE_SAND, ELE_RES_POTION, PALLADIUM_SCRAP }, 8887774);
            Create(Main.Items.HELLSTONE_OF_INCORPORATION, new List<int>() { HACKMANITE, BLUE_SAND, GABBERY_WINE, FIREFLY_POWDER }, 8887774);
            Create(Main.Items.HELLSTONE_OF_ARCANA, new List<int>() { MANA_STONE, SPIRITUAL_VARNISH , AZURE_SHRIMP }, 8887775);

        }

        public static List<RecipeItem> recipeItems = new List<RecipeItem>();

        private static void Create(Item result, List<int> ingredients, int recipeItemID)
        {
            SL_Recipe recipe = new SL_Recipe();

            recipe.UID = Main.MODID + ":" + result.ItemID;

            recipe.Ingredients = new List<Ingredient>();

            foreach ( int id in ingredients)
            {
                Ingredient ing = new Ingredient();
                ing.Ingredient_ItemID = id;
                ing.Type = RecipeIngredient.ActionTypes.AddSpecificIngredient;

                recipe.Ingredients.Add(ing);
            }

            SL_Recipe.ItemQty slresult = new SL_Recipe.ItemQty();
            slresult.ItemID = result.ItemID;
            slresult.Quantity = 1;

            recipe.Results = new List<SL_Recipe.ItemQty>() { slresult };

            recipe.StationType = Recipe.CraftingType.Survival;

            recipe.ApplyRecipe();

           
            RecipeItem recipeitem = (RecipeItem)CustomItems.CreateCustomItem(new SL_Item()
            {             
                Name = "Crafting: " + result.Name,   
                Description = "Teaches you how to craft the item.",
                Target_ItemID = 5700118, // a recipe item id
                New_ItemID = recipeItemID,              
                IsUsable = true
                
            });

            Log.Print("recpe");
            recipeitem.Recipe = CustomItems.ALL_RECIPES[recipe.UID];

            recipeItems.Add(recipeitem);

        }
    }

    }
