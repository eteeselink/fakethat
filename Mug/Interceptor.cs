using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MugMocks
{
    internal class Interceptor : Castle.DynamicProxy.IInterceptor
    {
        private class Operation
        {
            public Delegate Delegate;
            public int Calls = 0;
        }

        private Dictionary<string, Operation> operations = new Dictionary<string, Operation>();

        /// <summary>
        /// Register <paramref name="instead"/> to be executed when <paramref name="method"/> is called.
        /// Uses MethodInfo.ToString(), which uniquely identifies any possible signature.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="instead"></param>
        public void RegisterOperation(MethodInfo method, Delegate instead)
        {
            operations[method.ToString()] = new Operation() { Delegate = instead };
        }

        public int CountCalls(MethodInfo method)
        {
            string methodSignature = method.ToString();
            if (!operations.ContainsKey(methodSignature))
            {
                throw new MethodNotStubbedException("CountCalls invoked on " + method.ToString() + " but it was not registered with a Stub() call (on an object of type " + method.DeclaringType.Name + ")");
            }
            return operations[method.ToString()].Calls;
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            // find registered operation, and invoke it if possible.
            string methodSignature = invocation.Method.ToString();
            if (!operations.ContainsKey(methodSignature))
            {
                throw new MethodNotStubbedException(invocation.Method.Name + " was called but not registered with a Stub() call (on an object of type " + invocation.Method.DeclaringType.Name + ")");
            }

            var operation = operations[methodSignature];
            try
            {
                invocation.ReturnValue = operation.Delegate.DynamicInvoke(invocation.Arguments);
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                throw e.InnerException;
            }
            operation.Calls++;
        }
    }
}
