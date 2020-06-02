using SideLoader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using UnityEngine;

namespace grindward
{
    public class MobClassifier
    {
        

        static float HP = 0.005F;
        static float RES = 0.001F;
        static float PROTECTION = 0.05F;

        public static float GetLootMulti(Character mob)
        {
            float multi = 1;

            multi += HP * mob.Stats.MaxHealth;
            multi += PROTECTION * mob.Stats.GetDamageProtection(DamageType.Types.Physical);


            float res = 0;

            foreach (DamageType.Types type in EnumUtils.Elements())
            {
                 res += mob.Stats.GetDamageResistance(type);               

            }
            multi += RES * res;


            return multi;
        }


    }
}
