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

            for (int i = 0; i < 1; i++) // change I to big number to test loot drops
            {

                bool dropGear = false;

                if (source == DiabloItemExtension.ItemSource.ChestLoot)
                {
                    float multi = 2;

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
                    if (character is Character)
                    {
                        float chance = 2 + (MobUtils.GetLootMulti(character) * 2);
                        dropGear = RandomUtils.Roll(chance);

                        Log.Debug("Loot generating with chance " + chance + " " + dropGear);
                    }
                    else
                    {
                        Log.Print("Character null when trying to generate loot???");
                    }
                }


                if (!dropGear)
                {
                    continue;
                }

                Tier tier = Registry.Tiers.GetAll().RandomWeighted();

                if (character)
                {
                    tier = Tier.TierGetTierOfMob(character);
                }
                else
                {
                    Log.Debug("No character, using random tiers");
                }

                Tier itemTier = tier.GetRandomItemDropTier();

                GearType type = RandomUtils.WeightedRandom(Registry.GearTypes.GetAll());

                Item randomItem = RandomUtils.RandomFromList(type.GetAllItemsOfTier(itemTier));

                Item generatedItem = ItemManager.Instance.GenerateItemNetwork(randomItem.ItemID);

                if (generatedItem is Item)
                {
                    generatedItem.GetComponent<DiabloItemExtension>().isMagical = true;

                    generatedItem.ChangeParent(container.transform); // container.additem() bugs out, use this instead. DONT ASK WHY

                    Log.Debug("Generated item and added to loot container: " + generatedItem.Name);

                }
            }
            
        }
    }
}
