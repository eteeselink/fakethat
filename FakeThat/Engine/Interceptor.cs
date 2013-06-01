using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FakeThat.Engine
{
    internal class Interceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly SetterRegistry setterRegistry;

        private class Operation
        {
            public Delegate Delegate;
            public StubbedOperationBase StubbedOperation;
        }

        private Dictionary<string, Operation> operations = new Dictionary<string, Operation>();

        public Interceptor(SetterRegistry registry)
        {
            this.setterRegistry = registry;
        }

        /// <summary>
        /// Register <paramref name="instead"/> to be executed when <paramref name="method"/> is called.
        /// Uses MethodInfo.ToString(), which uniquely identifies any possible signature.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="instead"></param>
        public void RegisterOperation(MethodInfo method, Delegate instead, StubbedOperationBase stubbedOperation)
        {
            operations[method.ToString()] = new Operation() 
            { 
                Delegate = instead,
                StubbedOperation = stubbedOperation
            };
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            // find registered operation, and invoke it if possible.
            string methodSignature = invocation.Method.ToString();
            if (!operations.ContainsKey(methodSignature))
            {
                //// the setterRegistry only has a 'latest setter' if a setter has been recently (implicitly) converted
                //// to the property type, typically on a call that invoked this particular `Intercept` call. In that case,
                //// we want to newly tie the given setter to this invocation
                //if (methodSignature.StartsWith("Void set_") && setterRegistry.HasLatestSetter())
                //{
                //    RegisterOperation(invocation.Method, setterRegistry.UseLatestSetter());
                //}
                //else
                {
                    throw new MethodNotStubbedException(invocation.Method.Name + " was called but not registered with a Stub() call (on an object of type " + invocation.Method.DeclaringType.Name + ")");
                }
            }

            var operation = operations[methodSignature];

            // keep track of our arguments for user lookup later
            IEnumerable<object> arguments = invocation.Arguments;
            try
            {
                object retval = operation.Delegate.DynamicInvoke(invocation.Arguments);
                if (operation.Delegate.Method.ReturnType != typeof(void))
                {
                    // prepend the return value to the argument list, as per StubbedOperationBase.AddCall's signature
                    arguments = arguments.Concat(new[] { retval });                    
                }
                
                invocation.ReturnValue = retval;
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                throw e.InnerException;
            }

            operation.StubbedOperation.RememberCall(arguments.ToArray());
        }
    }
}
