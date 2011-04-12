using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Castle.DynamicProxy.Generators;
using System.Reflection;

namespace MugMocks
{
    /// <summary>
    /// Thrown when <see cref="Mug.On"/> is called on an object not created with <see cref="Mug.Mock"/>.
    /// </summary>
    public class NotAMugObjectException : Exception
    {
        internal NotAMugObjectException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Thrown when a method on a mocked object is called without it having been registered with <see cref="Mug.On"/>.
    /// </summary>
    public class MethodNotStubbedException : Exception
    {
        internal MethodNotStubbedException(string msg) : base(msg) { }
    }

    internal class Interceptor : IInterceptor
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

        public void Intercept(IInvocation invocation)
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
                throw new MethodNotStubbedException(invocation.Method.Name + " was called but not registered with an On() call (on an object of type " + invocation.Method.DeclaringType.Name + ")");
            }
        }
    }

    /// <summary>
    /// The main Mug class. Contains static methods to create mock objects and to stub methods on them.
    /// </summary>
    public static class Mug
    {
        //i genuinely hope this guarantees a map-by-object reference. too noob to tell!
        static Dictionary<object, Interceptor> ceptors = new Dictionary<object, Interceptor>();

        /// <summary>
        /// Create a new mock object of the type specified by <typeparamref name="TObj"/>. Call <see cref="Mug.On"/> for
        /// defining what should happen when an operation is called on said object.
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        /// <returns>A new mock object.</returns>
        public static TObj Mock<TObj>() where TObj : class
        {
            var gen = new ProxyGenerator();
            var interceptor = new Interceptor();

            TObj obj = gen.CreateInterfaceProxyWithoutTarget<TObj>(interceptor);
            ceptors[obj] = interceptor;
            return obj;
        }

        private static Interceptor GetInterceptor(Delegate action)
        {
            object target = action.Target;
            if (!ceptors.ContainsKey(target))
            {
                throw new NotAMugObjectException("The referenced object (of type " + target.GetType() + ") has not been created with Mug.Mock()");
            }
            return ceptors[target];
        }

        private static void Stub(Delegate methodDelegate, Delegate instead)
        {
            GetInterceptor(methodDelegate).RegisterOperation(methodDelegate.Method, instead);
        }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On(Action method, Action stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<T1>(Action<T1> method, Action<T1> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<T1, T2>(Action<T1, T2> method, Action<T1, T2> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<T1, T2, T3>(Action<T1, T2, T3> method, Action<T1, T2, T3> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, Action<T1, T2, T3, T4> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<TRet>(Func<TRet> method, Func<TRet> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<TRet, T1>(Func<TRet, T1> method, Func<TRet, T1> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<TRet, T1, T2>(Func<TRet, T1, T2> method, Func<TRet, T1, T2> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<TRet, T1, T2, T3>(Func<TRet, T1, T2, T3> method, Func<TRet, T1, T2, T3> stub) { Stub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public static void On<TRet, T1, T2, T3, T4>(Func<TRet, T1, T2, T3, T4> method, Func<TRet, T1, T2, T3, T4> stub) { Stub(method, stub); }

    }

}
