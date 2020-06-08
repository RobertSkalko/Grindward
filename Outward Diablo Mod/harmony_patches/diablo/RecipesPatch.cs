using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.harmony_patches.diablo
{


    [HarmonyPatch(typeof(CharacterInventory), "InventoryIngredients",
        new Type[] { typeof(Tag) , typeof(DictionaryExt<int, CompatibleIngredient>) , typeof(IList<Item>) }
        , new ArgumentType[] { ArgumentType.Normal, ArgumentType.Ref, ArgumentType.Normal }        
        )]
    public class InvPatch
    {
        [HarmonyPrefix]
        public static void Prefix(ItemManager __instance, ref Tag ___0, DictionaryExt<int, CompatibleIngredient> ___1, IList<Item> ___2)
        {
            foreach (Item item in ___2)
            {
                if (!item.HasTag(___0)){

                    if (ItemUtils.IsValidGear(item) || item.HasTag(new Tag(Items.CURRENCY_TAG)))
                    {
                        CompatibleIngredient compatibleIngredient = null;

                        if (!___1.TryGetValue(item.ItemID, out compatibleIngredient))
                        {
                            compatibleIngredient = new CompatibleIngredient(item.ItemID);
                            ___1.Add(item.ItemID, compatibleIngredient);
                        }
                       
                        if (compatibleIngredient != null)
                        {
                            compatibleIngredient.AddOwnedItem(item);
                        }
                    }

                }
            }
         
        }
    }
     [HarmonyPatch(typeof(ItemManager), "ConsumeCraftingItems")]
    public class RecipesPatch
    {
        [HarmonyPrefix]
        public static void Prefix(ItemManager __instance, ref KeyValuePair<string, int>[] ___1)
        {

            Item gear = null;

            Item currency = null;
                        
            bool failed = false;

            List<Item> others = new List<Item>();

            foreach (KeyValuePair<string, int> pair in ___1)
            {

                Item current = __instance.GetItem(pair.Key);

                if (current != null)
                {
                    if (ItemUtils.IsValidGear(current))
                    {
                        if (gear != null)
                        {
                            failed = true;
                            continue;
                        }

                        gear = current;
                        continue;
                    }
                   else if (current.HasTag(new Tag(Items.CURRENCY_TAG)))
                    {
                        if (currency != null)
                        {
                            failed = true;
                            continue;
                        }
                        currency = current;
                        continue;

                    }
                    else
                    {                       
                        others.Add(current);
                        failed = true;
                        continue;
                        
                    }
                }                
            } 


            if (gear != null && currency != null)
            {
                ItemContainer cont = gear.OwnerCharacter.Inventory.Pouch;

                if (failed)
                {

                    others.Add(gear);

                    foreach (Item item in others)
                    {                      
                        ItemManager.Instance.CloneItem(item).ChangeParent(cont.transform); // container.additem() bugs out, use this instead. DONT ASK WHY
                    }
                }
                else
                {
                    // todo

                    Item modifiedGear = ItemManager.Instance.CloneItem(gear);

                    DiabloItemExtension ext= modifiedGear.GetComponent<DiabloItemExtension>();

                    if (ext.HasSuffix())
                    {
                        ext.suffix.Randomize(modifiedGear);
                    }
                    if (ext.HasPrefix())
                    {
                        ext.prefix.Randomize(modifiedGear);
                    }

                    modifiedGear.ChangeParent(cont.transform);
                }

            }

        }
    }

}
