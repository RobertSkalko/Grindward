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
						UseOnGear((Equipment)items[0], character);	

					}								
			}			
		}
		public void UseOnGear(Equipment item, Character character)
		{
			DiabloItemExtension ext = item.GetComponent<DiabloItemExtension>();

			if (!ext.IsValidRandomDrop())
            {
				character.CharacterUI.ShowInfoNotification("This item isn't a random drop, and therefore hellstones can't be used on it. ");
				Item back = ItemManager.Instance.GenerateItemNetwork(ParentItem.ItemID);
				back.ChangeParent(character.Inventory.Pouch.transform);
				return;
			}

			var list = CurrencyEffects.ALL[this.ParentItem.ItemID];

			var effect = list.RandomWeighted().Get();
			
			effect.ChangeItem(item);

			character.CharacterUI.ShowInfoNotification(effect.GetChatNotification());

		}
	}
}
