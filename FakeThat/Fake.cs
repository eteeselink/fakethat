using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FakeThat.Engine;
using System.Linq.Expressions;
using System.Collections.Concurrent;

namespace FakeThat
{
    /// <summary>
    /// Base class for all fake object wrappers.
    /// </summary>
    public abstract class Fake
    {

#if DEBUG
        private static ConcurrentDictionary<object, WeakReference> fakes = new ConcurrentDictionary<object, WeakReference>(new IdentityEqualityComparer<object>());

        public static T New<T>() where T : class
        {
            var fake = new Fake<T>();
            return fake.Object;
        }

        internal static Fake<T> Get<T>(T obj) where T : class
        {
            return (Fake<T>)fakes[obj].Target;
        }

        protected void Remember<T>(Fake<T> fake) where T : class
        {
            fakes.TryAdd(fake.Object, new WeakReference(fake));
        }
#endif
    }

#if DEBUG
    public static class FakeExtensions
    {
        public static FuncCallHistory<T1, TRet> Stub<TObj, T1, TRet>(this TObj obj, Func<T1, TRet> method, Func<T1, TRet> stub) where TObj : class
        {
            var fake = Fake.Get<TObj>(obj);
            return fake.Stub(method, stub);
        }
    }
#endif

    /// <summary>
    /// Encapsulates a fake object of type `TObj`. Use <see cref="Object"/> to obtain the actual fake object.
    /// </summary>
    public partial class Fake<TObj> : Fake 
        where TObj : class
    {
        private readonly Interceptor interceptor;

        /// <summary>
        /// The actual fake object. Pass this to your software under test.
        /// </summary>
        public TObj Object { get; private set; }

        /// <summary>
        /// Create a new fake object. Access the underlying object itself through <see cref="Fake{TObj}.Object"/>.
        /// </summary>
        /// <param name="autoStub">
        /// If true, any unstubbed methods are given do-nothing implementations. Otherwise,
        /// calling an unstubbed method results in an exception.
        /// </param>
        public Fake(bool autoStub)
        {
            var gen = new Castle.DynamicProxy.ProxyGenerator();
            interceptor = new Interceptor();

            Object = gen.CreateInterfaceProxyWithoutTarget<TObj>(interceptor);
#if DEBUG
            Remember(this);
#endif
        }

        /// <summary>
        /// Create a new fake object. Access the underlying object itself through `Fake{TObj}.Object`.
        /// Calling an unstubbed method results in an exception. Use <see cref="Fake{TObj}.Fake(bool)"/> to change this behaviour.
        /// </summary>
        public Fake()
            : this(false)
        { }

        private T RegisterStub<T>(Delegate methodDelegate, Delegate instead, T stubbedOperation) where T : CallHistoryBase
        {
            interceptor.RegisterOperation(methodDelegate.Method, instead, stubbedOperation);
            return stubbedOperation;
        }

        /// <summary>
        /// Execute `onGet` when the property specified in `propertyLookupExpression` is called. For example,
        /// call `<code>fake.StubGetter(() => fake.Object.MyProperty, () => 5)</code>` to always return five.
        /// </summary>
        public FuncCallHistory<TProp> StubGetter<TProp>(Expression<Func<TProp>> propertyLookupExpression, Func<TProp> onGet)
        {
            var lambda = PropertyLambda<TObj>.Create(propertyLookupExpression);
            var stubbedOperation = new FuncCallHistory<TProp>();
            interceptor.RegisterOperation(lambda.Getter, onGet, stubbedOperation);
            return stubbedOperation;
        }       

        /// <summary>
        /// Execute `onSet` when the property specified in `setterCall` is set. Call syntax:
        /// `<code>fake.StubSetter(v => fake.Object.SomeProperty = v, value => { ... });</code>`
        /// </summary>
        /// <param name="setterCall">Pass a lambda of the following form: <code>v => fake.Object.SomeProperty = v</code>.</param>
        /// <param name="onSet">The action to perform whenever the property is set</param>
        public ActionCallHistory<TProp> StubSetter<TProp>(Action<FakeValue<TProp>> setterCall, Action<TProp> onSet)
        {
            var callHistory = new ActionCallHistory<TProp>();
            interceptor.ExpectSetter(onSet, callHistory);
            setterCall(new FakeValue<TProp>());
            interceptor.UnexpectSetter();

            return callHistory;
        }

        /// <summary>
        /// Assembly loading hook for embedding Castle.Core.dll right into FakeThat.dll.
        /// stolen from http://blogs.msdn.com/b/microsoft_press/archive/2010/02/03/jeffrey-richter-excerpt-2-from-clr-via-c-third-edition.aspx
        /// </summary>
        static Fake()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = typeof(Fake).Namespace + "." +
                   new AssemblyName(args.Name).Name + ".dll";

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }
    }

}
