using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace grindward
{

	// setting my own item as consumable/usable gives null errors, unless i manually patch this method.
	[HarmonyPatch(typeof(ItemListDisplay), "SortByConsumable")]
	public class UsseableItemFixPatch
	{

		[HarmonyPrefix]
		public static bool Prefix(ref int __result, Item ___0, Item ___1)
		{

			try {
				if (___0.HasTag(Items.CURRENCY_TAG) && ___1.HasTag(Items.CURRENCY_TAG))
				{
					__result = 0;
					return false;
				}
			}
			catch(Exception e) {}


			return true;
		}
	}


}
