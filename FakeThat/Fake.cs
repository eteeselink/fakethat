using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FakeThat.Engine;
using System.Linq.Expressions;

namespace FakeThat
{
    public abstract class Fake
    {
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

    public partial class Fake<TObj> : Fake 
        where TObj : class
    {
        private readonly Interceptor interceptor;

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
        /// Execute `resultFunc` when the property specified in `propertyLookupExpression` is called. For example,
        /// call `fake.StubGetter(() => fake.Object.MyProperty, () => 5)` to always return five.
        /// </summary>
        /// <returns></returns>
        public StubbedFunc<TProp> StubGetter<TProp>(Expression<Func<TProp>> propertyLookupExpression, Func<TProp> resultFunc)
        {
            var lambda = PropertyLambda<TObj>.Create(propertyLookupExpression);
            var stubbedOperation = new StubbedFunc<TProp>();
            interceptor.RegisterOperation(lambda.Getter, resultFunc, stubbedOperation);
            return stubbedOperation;
        }

        public StubbedSetter<TProp> StubSetter<TProp>(Action<TProp> onSet)
        {
            return new StubbedSetter<TProp>();
        }

        public StubbedAction<TProp> StubSetter<TProp>(Action<FakeValue<TProp>> setterCall, Action<TProp> onSet)
        {
            var stubbedOperation = new StubbedAction<TProp>();
            interceptor.ExpectSetter(onSet, stubbedOperation);
            setterCall(new FakeValue<TProp>());
            interceptor.UnexpectSetter();

            return stubbedOperation;
        }
    }

}
