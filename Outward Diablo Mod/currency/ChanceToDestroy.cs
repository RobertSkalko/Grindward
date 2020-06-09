using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class ChanceToDestroy : ItemChanger
    {
        int chance;

        public ChanceToDestroy(int chance)
        {
            this.chance = chance;
        }

        public override void ChangeItem(Equipment item)
        {
           if (RandomUtils.Roll(chance))
            {
                ItemManager.Instance.DestroyItem(item.UID);
            }
        }

        public override string GetDescription()
        {
            return chance + "% Chance To Destroy the item.";
        }
    }
}
