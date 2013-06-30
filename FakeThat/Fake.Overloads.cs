using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeThat.Calls;

namespace FakeThat
{
    public partial class Fake<TObj> 
        where TObj : class
    {
		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory Stub(Action method, Action stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory Stub(Action method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1> Stub<T1>(Action<T1> method, Action<T1> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1> Stub<T1>(Action<T1> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2> Stub<T1, T2>(Action<T1, T2> method, Action<T1, T2> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2> Stub<T1, T2>(Action<T1, T2> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2, T3> Stub<T1, T2, T3>(Action<T1, T2, T3> method, Action<T1, T2, T3> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2, T3>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2, T3> Stub<T1, T2, T3>(Action<T1, T2, T3> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2, T3>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2, T3, T4> Stub<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, Action<T1, T2, T3, T4> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2, T3, T4>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2, T3, T4> Stub<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2, T3, T4>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2, T3, T4, T5> Stub<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method, Action<T1, T2, T3, T4, T5> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2, T3, T4, T5>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2, T3, T4, T5> Stub<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2, T3, T4, T5>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2, T3, T4, T5, T6> Stub<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method, Action<T1, T2, T3, T4, T5, T6> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2, T3, T4, T5, T6>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2, T3, T4, T5, T6> Stub<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2, T3, T4, T5, T6>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2, T3, T4, T5, T6, T7> Stub<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method, Action<T1, T2, T3, T4, T5, T6, T7> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2, T3, T4, T5, T6, T7>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2, T3, T4, T5, T6, T7> Stub<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2, T3, T4, T5, T6, T7>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public ActionCallHistory<T1, T2, T3, T4, T5, T6, T7, T8> Stub<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, Action<T1, T2, T3, T4, T5, T6, T7, T8> stub) 
		{ 
			return RegisterStub(method, stub, new ActionCallHistory<T1, T2, T3, T4, T5, T6, T7, T8>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Action for the second argument.
        /// </remarks>
		public ActionCallHistory<T1, T2, T3, T4, T5, T6, T7, T8> Stub<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method) 
		{ 
			return RegisterStub(method, null, new ActionCallHistory<T1, T2, T3, T4, T5, T6, T7, T8>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<TRet> Stub<TRet>(Func<TRet> method, Func<TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<TRet> Stub<TRet>(Func<TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, TRet> Stub<T1, TRet>(Func<T1, TRet> method, Func<T1, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, TRet> Stub<T1, TRet>(Func<T1, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, TRet> Stub<T1, T2, TRet>(Func<T1, T2, TRet> method, Func<T1, T2, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, TRet> Stub<T1, T2, TRet>(Func<T1, T2, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, T3, TRet> Stub<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> method, Func<T1, T2, T3, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, T3, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, T3, TRet> Stub<T1, T2, T3, TRet>(Func<T1, T2, T3, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, T3, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, T3, T4, TRet> Stub<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> method, Func<T1, T2, T3, T4, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, T3, T4, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, T3, T4, TRet> Stub<T1, T2, T3, T4, TRet>(Func<T1, T2, T3, T4, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, T3, T4, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, T3, T4, T5, TRet> Stub<T1, T2, T3, T4, T5, TRet>(Func<T1, T2, T3, T4, T5, TRet> method, Func<T1, T2, T3, T4, T5, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, T3, T4, T5, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, T3, T4, T5, TRet> Stub<T1, T2, T3, T4, T5, TRet>(Func<T1, T2, T3, T4, T5, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, T3, T4, T5, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, T3, T4, T5, T6, TRet> Stub<T1, T2, T3, T4, T5, T6, TRet>(Func<T1, T2, T3, T4, T5, T6, TRet> method, Func<T1, T2, T3, T4, T5, T6, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, T3, T4, T5, T6, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, T3, T4, T5, T6, TRet> Stub<T1, T2, T3, T4, T5, T6, TRet>(Func<T1, T2, T3, T4, T5, T6, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, T3, T4, T5, T6, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, TRet> Stub<T1, T2, T3, T4, T5, T6, T7, TRet>(Func<T1, T2, T3, T4, T5, T6, T7, TRet> method, Func<T1, T2, T3, T4, T5, T6, T7, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, TRet> Stub<T1, T2, T3, T4, T5, T6, T7, TRet>(Func<T1, T2, T3, T4, T5, T6, T7, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, TRet>()); 
		}

		/// <summary>
		/// Execute `<paramref name="stub"/>` when `<paramref name="method"/>` is called. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
		/// </summary>
		public FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, T8, TRet> Stub<T1, T2, T3, T4, T5, T6, T7, T8, TRet>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TRet> method, Func<T1, T2, T3, T4, T5, T6, T7, T8, TRet> stub) 
		{ 
			return RegisterStub(method, stub, new FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, T8, TRet>()); 
		}

		/// <summary>
		/// Keep track of calls to `<paramref name="method"/>`. 
		/// `<paramref name="method"/>` must be a method of `<i>this</i>.Object`. 
		/// Returns `CallHistory` object that keeps track of all calls made to the stubbed method.
        /// Call syntax: `fake.Stub&lt;string, int&gt;(fake.Object.ParseStr)`.
		/// </summary>
        /// <remarks>
        /// Calling this method is equivalent to calling `Stub()`'s two-parameter overload, with
        /// a dummy Func for the second argument.
        /// </remarks>
		public FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, T8, TRet> Stub<T1, T2, T3, T4, T5, T6, T7, T8, TRet>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TRet> method) 
		{ 
			return RegisterStub(method, null, new FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, T8, TRet>()); 
		}

	}
}
