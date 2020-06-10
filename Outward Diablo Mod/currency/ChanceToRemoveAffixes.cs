using grindward.database.affixes;
using grindward.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class ChanceToRemoveAffixes : ItemChanger
    {
        int chance;

        public ChanceToRemoveAffixes(int chance)
        {
            this.chance = chance;
           
        }

        public override void ChangeItem(Equipment item)
        {
            if (RandomUtils.Roll(chance))
            {
                DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

                if (ext.HasSuffix())
                {
                    ext.suffix.ClearAffix(item);
                }
                if (ext.HasPrefix())
                {
                    ext.prefix.ClearAffix(item);
                }
            }
        }

        public override string GetDescription()
        {
            return chance + "% Chance To Remove All affixes.";
        }
    }
}
