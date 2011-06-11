using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace MugMocks
{
    

    /// <summary>
    /// The main Mug class. Contains methods to create mock objects and to stub methods on them.
    /// </summary>
    public class Mug
    {
        //i genuinely hope this guarantees a map-by-object reference. too noob to tell!
        private Dictionary<object, Interceptor> ceptors = new Dictionary<object, Interceptor>();

        static Mug()
        {
            // assembly loading hook for embedding Castle.Core.dll right into Mug.dll.
            // stolen from http://blogs.msdn.com/b/microsoft_press/archive/2010/02/03/jeffrey-richter-excerpt-2-from-clr-via-c-third-edition.aspx
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = "Mug." +
                   new AssemblyName(args.Name).Name + ".dll";

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }

        /// <summary>
        /// Create a new mock object of the type specified by <typeparamref name="TObj"/>. Call <see cref="Mug.Stub"/> for
        /// defining what should happen when an operation is called on said object.
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        /// <returns>A new mock object.</returns>
        public TObj Mock<TObj>() where TObj : class
        {
            var gen = new Castle.DynamicProxy.ProxyGenerator();
            var interceptor = new Interceptor();

            TObj obj = gen.CreateInterfaceProxyWithoutTarget<TObj>(interceptor);
            ceptors[obj] = interceptor;
            return obj;
        }

        private Interceptor GetInterceptor(object target)
        {
            if (!ceptors.ContainsKey(target))
            {
                throw new NotAMugObjectException("The referenced object (of type " + target.GetType() + ") has not been created with Mug.Mock()");
            }
            return ceptors[target];
        }

        private void RegisterStub(Delegate methodDelegate, Delegate instead)
        {
            GetInterceptor(methodDelegate.Target).RegisterOperation(methodDelegate.Method, instead);
        }

        private void RegisterPropertyStub(Delegate methodDelegate, Delegate instead)
        {
            GetInterceptor(methodDelegate.Target).RegisterOperation(methodDelegate.Method, instead);
        }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub(Action method, Action stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<T1>(Action<T1> method, Action<T1> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<T1, T2>(Action<T1, T2> method, Action<T1, T2> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<T1, T2, T3>(Action<T1, T2, T3> method, Action<T1, T2, T3> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, Action<T1, T2, T3, T4> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<TRet>(Func<TRet> method, Func<TRet> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<TRet, T1>(Func<TRet, T1> method, Func<TRet, T1> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<TRet, T1, T2>(Func<TRet, T1, T2> method, Func<TRet, T1, T2> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<TRet, T1, T2, T3>(Func<TRet, T1, T2, T3> method, Func<TRet, T1, T2, T3> stub) { RegisterStub(method, stub); }

        /// <include file='Mug.xdoc' path='docs/doc[@name="Mug.On"]/*' />
        public void Stub<TRet, T1, T2, T3, T4>(Func<TRet, T1, T2, T3, T4> method, Func<TRet, T1, T2, T3, T4> stub) { RegisterStub(method, stub); }

        public string StubProperty<TObj, TRet>(TObj obj, Expression<Func<TObj, TRet>> propertyLookupExpression, Func<TRet> resultFunc)
        {
            if (propertyLookupExpression.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new Exception(@"Expected an expression of the form ""o => o.[some property]"".");
            }
            var expression = (MemberExpression)propertyLookupExpression.Body;
            return expression.Member.Name;
        }

    }

}
