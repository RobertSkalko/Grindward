using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace grindward.Reflection
{
    public class SafeMethod<ReflectedClassType, MethodReturnType>
    {
        MethodInfo method;

        int paramCount;

        public SafeMethod(String methodName)
        {
            this.method = typeof(ReflectedClassType).GetMethod(methodName, ReflectionUtils.flags);

            this.paramCount = method.GetParameters().Length;
          
        }

        public void CallNoParams(ReflectedClassType obj)
        {
            if (paramCount != 0)
            {
                Console.WriteLine(method.ToString() + " needs params!");
            }

           method.Invoke(obj, new object[] { });

        }

            public MethodReturnType Call(ReflectedClassType obj, object[] objs)
        {
            if (paramCount != objs.Length)
            {
                Console.WriteLine(method.ToString() + " needs different amount of params!");
            }

            var ret = method.Invoke(obj, objs);

            if (ret is MethodReturnType)
            {
                return (MethodReturnType)ret;
            }
            else
            {
                return default(MethodReturnType);
            }

        }
   
    }


}
