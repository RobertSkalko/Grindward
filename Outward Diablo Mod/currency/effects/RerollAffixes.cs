using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward.currency
{
    class RerollAffixes : ItemChanger
    {
        public override void ChangeItem(Equipment item)
        {
            DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

            if (ext.HasSuffix())
            {
                ext.suffix.Randomize(item);
            }
            if (ext.HasPrefix())
            {
                ext.prefix.Randomize(item);
            }
        }

        public override string GetDescription()
        {
            return "Rerolls affixes of the item. If it has them.";
        }
    }
}
