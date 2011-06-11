using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MugMocks
{
    internal class Interceptor : Castle.DynamicProxy.IInterceptor
    {
        private Dictionary<string, Delegate> operations = new Dictionary<string, Delegate>();

        /// <summary>
        /// Register <paramref name="instead"/> to be executed when <paramref name="method"/> is called.
        /// Uses MethodInfo.ToString(), which uniquely identifies any possible signature.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="instead"></param>
        public void RegisterOperation(MethodInfo method, Delegate instead)
        {
            operations[method.ToString()] = instead;
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            // find registered operation, and invoke it if possible.
            string methodSignature = invocation.Method.ToString();
            if (operations.ContainsKey(methodSignature))
            {
                var oper = operations[methodSignature];
                invocation.ReturnValue = oper.DynamicInvoke(invocation.Arguments);
            }
            else
            {
                throw new MethodNotStubbedException(invocation.Method.Name + " was called but not registered with a Stub() call (on an object of type " + invocation.Method.DeclaringType.Name + ")");
            }
        }
    }
}
