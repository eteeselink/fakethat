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

        /// <summary>
        /// Pass a MemberExpression of the form "[closure object].[object].[property]"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>the value of [object]</returns>
        private object getTargetFromPropertyInvocation(MemberExpression expression)
        {
            // stolen from http://stackoverflow.com/questions/2616638/access-the-value-of-a-member-expression:

            // get the "[closure object].o" part
            var me = (MemberExpression)expression.Expression;

            // get the "[closure object]" part
            var ce = (ConstantExpression)me.Expression;

            // get the field in "[closure object]" named "o"
            var fieldInfo = ce.Value.GetType().GetField(me.Member.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            // get the field's value, i.e. the object itself.
            return (object)fieldInfo.GetValue(ce.Value);
        }

        private void StubProperty<TProp>(Expression<Func<TProp>> propertyLookupExpression, Delegate resultFunc, bool isGetter)
        {
            if (propertyLookupExpression.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new Exception(@"Expected an expression of the form ""o => o.[some property]"" for the second argument.");
            }

            // get the "[closure object].o.[some property]" part (i.e. drop the "() =>")
            var expression = (MemberExpression)propertyLookupExpression.Body;
            var target = getTargetFromPropertyInvocation(expression);

            string methodNamePrefix = (isGetter) ? "get_" : "set_";

            // get the reflection method for the actual getter, e.g. target.get_SomeProperty or target.set_SomeProperty
            var getter = target.GetType().GetMethod(methodNamePrefix + expression.Member.Name);
            GetInterceptor(target).RegisterOperation(getter, resultFunc);
        }

        /// <summary>
        /// Stub a property getter
        /// </summary>
        public void StubProperty<TProp>(Expression<Func<TProp>> propertyLookupExpression, Func<TProp> resultFunc)
        {
            StubProperty(propertyLookupExpression, resultFunc, true);
        }

        /// <summary>
        /// Stub a property setter
        /// </summary>
        public void StubProperty<TProp>(Expression<Func<TProp>> propertyLookupExpression, Action<TProp> resultFunc)
        {
            StubProperty(propertyLookupExpression, resultFunc, false);
        }

    }

}
