using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FakeThat.Engine
{
    internal class Interceptor : Castle.DynamicProxy.IInterceptor
    {
        private class Operation
        {
            public Delegate Delegate;
            public CallHistoryBase CallHistory;
        }

        private Dictionary<string, Operation> operations = new Dictionary<string, Operation>();

        public Interceptor()
        {
        }

        /// <summary>
        /// Register <paramref name="instead"/> to be executed when <paramref name="method"/> is called.
        /// Uses MethodInfo.ToString(), which uniquely identifies any possible signature.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="instead"></param>
        public void RegisterOperation(MethodInfo method, Delegate instead, CallHistoryBase stubbedOperation)
        {
            operations[method.ToString()] = new Operation() 
            { 
                Delegate = instead,
                CallHistory = stubbedOperation
            };
        }

        private Operation expectedSetterOperation = null;

        public void ExpectSetter(Delegate setterStub, CallHistoryBase callHistory)
        {
            this.expectedSetterOperation = new Operation
            {
                Delegate = setterStub,
                CallHistory = callHistory
            };
        }

        public void UnexpectSetter()
        {
            if (expectedSetterOperation != null)
            {
                expectedSetterOperation = null;
                throw new ThatsNotASetterException();
            }
        }

        public void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {
            // find registered operation, and invoke it if possible.
            string methodSignature = invocation.Method.ToString();
            if (!operations.ContainsKey(methodSignature))
            {
                // if expectedSetterOperation isn't null, it means that Fake.StubSetter was just called
                if (expectedSetterOperation != null)
                {
                    const string prefix = "Void set_";
                    if (!methodSignature.StartsWith(prefix))
                    {
                        throw new ThatsNotASetterException();
                    }
                    RegisterOperation(invocation.Method, expectedSetterOperation.Delegate, expectedSetterOperation.CallHistory);
                    expectedSetterOperation = null;
                    return;
                }
                else
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

            operation.CallHistory.RememberCall(arguments.ToArray());
        }
    }
}
