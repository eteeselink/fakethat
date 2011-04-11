using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Castle.DynamicProxy.Generators;
using System.Reflection;

namespace Mug
{
    public class NotAMugObjectException : Exception
    {
        public NotAMugObjectException(string msg) : base(msg) { }
    }
    public class MethodNotStubbedException : Exception
    {
        public MethodNotStubbedException(string msg) : base(msg) { }
    }

    public class Interceptor : IInterceptor
    {
        public Dictionary<MethodInfo, Delegate> operations = new Dictionary<MethodInfo,Delegate>();
        public void Intercept(IInvocation invocation)
        {
            foreach (var oper in operations)
            {
                if (oper.Key.Name == invocation.Method.Name)
                {
                    invocation.ReturnValue = oper.Value.DynamicInvoke(invocation.Arguments);
                    return;
                }
            }
            throw new MethodNotStubbedException(invocation.Method.Name + " was called but not registered with an On().Do() cycle (on an object of type " + invocation.TargetType + ")");
        }
    }

    public abstract class AbstractFuncHook
    {
        protected MethodInfo method;
        protected Interceptor interceptor;
        internal AbstractFuncHook(MethodInfo method, Interceptor interceptor)
        {
            this.method = method;
            this.interceptor = interceptor;
        }
        protected void StoreDo(Delegate action)
        {
            interceptor.operations[method] = action;
        }
    }

    public class FuncHook<TRet> : AbstractFuncHook
    {
        internal FuncHook(MethodInfo method, Interceptor interceptor) : base(method, interceptor) { }
        public void Do(Func<TRet> action) { StoreDo(action); }
    }
    public class FuncHook<T1, TRet> : AbstractFuncHook
    {
        internal FuncHook(MethodInfo method, Interceptor interceptor) : base(method, interceptor) { }
        public void Do(Func<T1, TRet> action) { StoreDo(action); }
    }
    public class FuncHook<T1, T2, TRet> : AbstractFuncHook
    {
        internal FuncHook(MethodInfo method, Interceptor interceptor) : base(method, interceptor) { }
        public void Do(Func<T1, T2, TRet> action) { StoreDo(action); }
    }
    public class FuncHook<T1, T2, T3, TRet> : AbstractFuncHook
    {
        internal FuncHook(MethodInfo method, Interceptor interceptor) : base(method, interceptor) { }
        public void Do(Func<T1, T2, T3, TRet> action) { StoreDo(action); }
    }
    public class FuncHook<T1, T2, T3, T4, TRet> : AbstractFuncHook
    {
        internal FuncHook(MethodInfo method, Interceptor interceptor) : base(method, interceptor) { }
        public void Do(Func<T1, T2, T3, T4, TRet> action) { StoreDo(action); }
    }

    public static class Mug
    {
        //i genuinely hope this guarantees a map-by-object reference. too noob to tell!
        static Dictionary<object, Interceptor> ceptors = new Dictionary<object, Interceptor>();

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

        public static FuncHook<TRet> On<TRet>(Func<TRet> action)
        {
            return new FuncHook<TRet>(action.Method, GetInterceptor(action));
        }
        public static FuncHook<T1, TRet> On<T1, TRet>(Func<T1, TRet> action)
        {
            return new FuncHook<T1, TRet>(action.Method, GetInterceptor(action));
        }
        public static FuncHook<T1, T2, TRet> On<T1, T2, TRet>(Func<T1, TRet> action)
        {
            return new FuncHook<T1, T2, TRet>(action.Method, GetInterceptor(action));
        }
        public static FuncHook<T1, T2, T3, TRet> On<T1, T2, T3, TRet>(Func<T1, TRet> action)
        {
            return new FuncHook<T1, T2, T3, TRet>(action.Method, GetInterceptor(action));
        }
        public static FuncHook<T1, T2, T3, T4, TRet> On<T1, T2, T3, T4, TRet>(Func<T1, TRet> action)
        {
            return new FuncHook<T1, T2, T3, T4, TRet>(action.Method, GetInterceptor(action));
        }
    }

}
