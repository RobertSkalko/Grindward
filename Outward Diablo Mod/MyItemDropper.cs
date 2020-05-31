using outward_diablo;
using outward_diablo.database;
using outward_diablo.database.gear_types;
using OutwardDiabloMod.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutwardDiabloMod
{
    public class MyItemDropper : DropTable
    {
        public MyItemDropper()
        {
            
        }

        public override int DropPossibilitiesCount { get => 1; }

        public override void GenerateDrop(ItemContainer _container)
        {
          
            GearType type = RandomUtils.WeightedRandom(Registry.GearTypes.GetAll());

            UnityEngine.Debug.Log("random gear type gotten");

            Item randomItem = RandomUtils.RandomFromList(type.GetAllItems());

            UnityEngine.Debug.Log("random item gotten");

            Item generatedItem = ItemManager.Instance.GenerateItemNetwork(randomItem.ItemID);

            UnityEngine.Debug.Log("item gened");

            generatedItem.GetComponent<DiabloItemExtension>().source = DiabloItemExtension.ItemSource.MobDrop;

            UnityEngine.Debug.Log("The ext is there");

            _container.AddItem(generatedItem);

            _container.AddSilver(500);

            UnityEngine.Debug.Log("added item to pouch");
        }
    }
}
