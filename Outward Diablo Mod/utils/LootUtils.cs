using grindward.database;
using grindward.database.gear_types;
using grindward.database.tiers.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.utils
{
   public class LootUtils
    {
          static float BaseChestDropChance = 1F;

        public static void TryGenerateLoot(ItemContainer container, Character character, DiabloItemExtension.ItemSource source, TreasureChest chest = null)
        {

            bool dropGear;

            if (source == DiabloItemExtension.ItemSource.ChestLoot)
            {
                float multi = 1;

                if (container is TreasureChest)
                {
                    if (chest.LootGenQuality == TreasureChest.LootQuality.Low)
                    {
                        multi = 1;
                    }
                    if (chest.LootGenQuality == TreasureChest.LootQuality.Med)
                    {
                        multi = 2;
                    }
                    if (chest.LootGenQuality == TreasureChest.LootQuality.High)
                    {
                        multi = 3;
                    }
                }
                dropGear = RandomUtils.Roll(BaseChestDropChance * multi);
            }
            else
            {
                dropGear = RandomUtils.Roll(MobUtils.GetLootMulti(character));
            }


         
            if (!dropGear)
            {
                return;
            }


                Tier tier = Registry.Tiers.GetAll().RandomWeighted();

                if (character)
                {
                    tier = Tier.TierGetTierOfMob(character);
                }

                Tier itemTier = tier.GetRandomItemDropTier();
                            
                GearType type = RandomUtils.WeightedRandom(Registry.GearTypes.GetAll());

             
                Item randomItem = RandomUtils.RandomFromList(type.GetAllItemsOfTier(itemTier));

         
                Item generatedItem = ItemManager.Instance.GenerateItemNetwork(randomItem.ItemID);

                if (generatedItem != null)
                {                 
                    generatedItem.GetComponent<DiabloItemExtension>().source = DiabloItemExtension.ItemSource.MobDrop;
                                      
                    generatedItem.ChangeParent(container.transform); // container.additem() bugs out, use this instead. DONT ASK WHY
                                      

                }


            
        }
    }
}
