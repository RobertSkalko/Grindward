using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace grindward
{
    public class SafeField<ReflectedClassType, FieldType>
    {       
        FieldInfo field;        

        public SafeField(String fieldName){
            this.field = typeof(ReflectedClassType).GetField(fieldName, ReflectionUtils.flags);            
        }

        public FieldType GetValue(ReflectedClassType obj)
        {

            if (!field.IsStatic && obj == null)
            {
                Console.WriteLine("Object given in ReflectFieldWrapper.GetValue() is null");
            }
            if (field.IsStatic && obj != null)
            {
                Console.WriteLine("Don't need to pass objects when getting static values");
            }
         

            if (field.IsStatic)
            {
                return (FieldType)field.GetValue(null);
            }
            else
            {
                return (FieldType)field.GetValue(obj);
            }
        }


        public void SetValue(ReflectedClassType obj, FieldType value)
        {
            field.SetValue(obj, value);
        }


    }
}
