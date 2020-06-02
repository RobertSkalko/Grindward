using HarmonyLib;
using grindward.database.affixes;
using System;


namespace grindward

{
    [HarmonyPatch(typeof(Item), "Name", MethodType.Getter)]
    public class EquipmentNamePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Item __instance, ref string __result)
        {
            if (ItemUtils.IsGear(__instance))
            {
                DiabloItemExtension ext = __instance.gameObject.GetComponent<DiabloItemExtension>();

                if (ext != null)
                {
                    String suffix = "";

                    if (ext.suffix != null && ext.suffix.GetSuffix() != null)
                    {
                        suffix = " " + ext.suffix.GetSuffix().GetName();
                    }

                    __result = __result + " " + suffix;
                }
            }
        }
    }



}
