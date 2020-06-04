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
                DiabloItemExtension ext = __instance.gameObject.GetComponent<DiabloItemExtension>();

                if (ext != null)
                {
                String suffix = "";
                String prefix = "";

                if (ext.suffix != null && ext.suffix.GetAffix() != null)
                {
                    suffix = " " + ext.suffix.GetAffix().GetName();
                }
                if (ext.prefix != null && ext.prefix.GetAffix() != null)
                {
                    prefix =  ext.prefix.GetAffix().GetName() + " ";
                }

                __result = prefix + __result + suffix;

                }            
        }
    }



}
