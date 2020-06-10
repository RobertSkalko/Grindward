using grindward.utils;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SideLoader.SL_Recipe;

namespace grindward
{
    public class Recipes
    {
        static int CRYSTAL_POWDER = 6600040;
        static int GOLD_LICH_MECHANISM = 6600210;
        static int OCCULT_REMAINS = 6600110;
        static int HORROR_CHITIN = 6600120;
        static int OBSIDIAN_SHARD = 6600200;

        static int HACKMANITE = 6200130;
        static int LARGE_EMERALD = 6200090;
        static int MEDIUM_RUBY = 6200110;
        static int SMALL_SAPPHIRE = 6200100;
        static int TINY_AQUAMARINE = 6200070;

        public static void Init()
        {
            Create(Items.HELLSTONE_OF_WITHDRAWAL_ID, new List<int>() { OCCULT_REMAINS, HACKMANITE, CRYSTAL_POWDER, SMALL_SAPPHIRE });

            Item item = ItemUtils.GetAllItemPrefabs()[Items.HELLSTONE_OF_WITHDRAWAL_ID + ""];
            Log.Print("test " + item.Name + " id " + item.ItemID );

        }

        private static void Create(int result, List<int> ingredients)
        {
            SL_Recipe recipe = new SL_Recipe();

            recipe.Ingredients = new List<Ingredient>();

            foreach ( int id in ingredients)
            {
                Ingredient ing = new Ingredient();
                ing.Ingredient_ItemID = id;
                ing.Type = RecipeIngredient.ActionTypes.AddSpecificIngredient;

                recipe.Ingredients.Add(ing);
            }

            SL_Recipe.ItemQty slresult = new SL_Recipe.ItemQty();
            slresult.ItemID = result;
            slresult.Quantity = 1;

            recipe.Results = new List<SL_Recipe.ItemQty>() { slresult };

            recipe.StationType = Recipe.CraftingType.Survival;

            recipe.ApplyRecipe();

        }
    }

    }
