using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grindward
{
    public class CurrencyEffect : Effect
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

		public static void UseOnGear(Equipment item)
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
	}
}
