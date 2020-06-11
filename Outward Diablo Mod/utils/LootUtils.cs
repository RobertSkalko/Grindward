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
          static float BaseChestDropChance = 4F;

        public static void TryGenerateLoot(ItemContainer container, Character character, DiabloItemExtension.ItemSource source)
        {

            bool dropGear;

            if (source == DiabloItemExtension.ItemSource.ChestLoot)
            {
                float multi = 1;

                if (container is TreasureChest)
                {
                    multi = 2;
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


           // for (int i = 0; i < 50; i++)
            //{

                GearType type = RandomUtils.WeightedRandom(Registry.GearTypes.GetAll());

                //Log.Debug("random gear type gotten");

                Item randomItem = RandomUtils.RandomFromList(type.GetAllItemsOfTier(itemTier));

                //Log.Debug("random item gotten");

                Item generatedItem = ItemManager.Instance.GenerateItemNetwork(randomItem.ItemID);

                if (generatedItem != null)
                {
                    //Log.Debug("item gened");

                    generatedItem.GetComponent<DiabloItemExtension>().source = DiabloItemExtension.ItemSource.MobDrop;

                    //Log.Debug("The ext is there");

                    generatedItem.ChangeParent(container.transform); // container.additem() bugs out, use this instead. DONT ASK WHY

                    //Log.Debug("added item to pouch");

                }

            
        }
    }
}
