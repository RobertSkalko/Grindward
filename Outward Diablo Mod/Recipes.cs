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
            Create(Items.HELLSTONE_OF_WITHDRAWAL_ID, new List<int>() { HACKMANITE, OCCULT_REMAINS, CRYSTAL_POWDER, SMALL_SAPPHIRE });
            Create(Items.HELLSTONE_OF_TEMPERING_ID, new List<int>() { LARGE_EMERALD, GOLD_LICH_MECHANISM, CRYSTAL_POWDER, OBSIDIAN_SHARD });


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
