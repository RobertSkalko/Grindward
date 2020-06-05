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

                if (ext.HasSuffix())
                {
                    suffix = " " + ext.suffix.GetAffix().GetName();
                }
                if (ext.HasPrefix())
                {
                    prefix =  ext.prefix.GetAffix().GetName() + " ";
                }

                __result = prefix + __result + suffix;

                }            
        }
    }



}
