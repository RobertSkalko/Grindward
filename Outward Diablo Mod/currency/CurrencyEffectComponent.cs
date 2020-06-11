using grindward.currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace grindward
{
    public class CurrencyEffectComponent : Effect
    {
        protected override void ActivateLocally(Character _affectedCharacter, object[] _infos)
		{			
				Character character = _affectedCharacter;

				if (character && character.Inventory && character.Inventory.Pouch)
				{
					List<Item> items = character.Inventory.Pouch.GetContainedItems().Where(x => ItemUtils.IsValidGear(x)).ToList();

					if (items.Count() == 1)
					{
						UseOnGear((Equipment)items[0]);	

					}								
			}			
		}

		public  void UseOnGear(Equipment item)
		{
			var list = CurrencyEffects.ALL[this.ParentItem.ItemID];

			list.RandomWeighted().Get().ChangeItem(item);	

		}
	}
}
