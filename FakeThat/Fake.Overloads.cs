using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat
{
    public partial class Fake<TObj> : Fake 
        where TObj : class
    {
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction Stub(Action method, Action stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1> Stub<T1>(Action<T1> method, Action<T1> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2> Stub<T1, T2>(Action<T1, T2> method, Action<T1, T2> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2, T3> Stub<T1, T2, T3>(Action<T1, T2, T3> method, Action<T1, T2, T3> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2, T3>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2, T3, T4> Stub<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, Action<T1, T2, T3, T4> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2, T3, T4>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2, T3, T4, T5> Stub<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method, Action<T1, T2, T3, T4, T5> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2, T3, T4, T5>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2, T3, T4, T5, T6> Stub<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method, Action<T1, T2, T3, T4, T5, T6> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2, T3, T4, T5, T6>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2, T3, T4, T5, T6, T7> Stub<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method, Action<T1, T2, T3, T4, T5, T6, T7> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2, T3, T4, T5, T6, T7>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedAction<T1, T2, T3, T4, T5, T6, T7, T8> Stub<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, Action<T1, T2, T3, T4, T5, T6, T7, T8> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedAction<T1, T2, T3, T4, T5, T6, T7, T8>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet> Stub<TRet>(Func<TRet> method, Func<TRet> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1> Stub<TRet, T1>(Func<TRet, T1> method, Func<TRet, T1> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2> Stub<TRet, T1, T2>(Func<TRet, T1, T2> method, Func<TRet, T1, T2> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2, T3> Stub<TRet, T1, T2, T3>(Func<TRet, T1, T2, T3> method, Func<TRet, T1, T2, T3> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2, T3>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2, T3, T4> Stub<TRet, T1, T2, T3, T4>(Func<TRet, T1, T2, T3, T4> method, Func<TRet, T1, T2, T3, T4> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2, T3, T4>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2, T3, T4, T5> Stub<TRet, T1, T2, T3, T4, T5>(Func<TRet, T1, T2, T3, T4, T5> method, Func<TRet, T1, T2, T3, T4, T5> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2, T3, T4, T5>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2, T3, T4, T5, T6> Stub<TRet, T1, T2, T3, T4, T5, T6>(Func<TRet, T1, T2, T3, T4, T5, T6> method, Func<TRet, T1, T2, T3, T4, T5, T6> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2, T3, T4, T5, T6>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7> Stub<TRet, T1, T2, T3, T4, T5, T6, T7>(Func<TRet, T1, T2, T3, T4, T5, T6, T7> method, Func<TRet, T1, T2, T3, T4, T5, T6, T7> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7>()); 
		}
		 
		/// <summary>
		/// Execute <paramref name="stub"/> when <paramref name="method"/> is called. <paramref name="method"/> must be a method of an object created with <see cref="Mock"/>.
		/// </summary>
		public StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7, T8> Stub<TRet, T1, T2, T3, T4, T5, T6, T7, T8>(Func<TRet, T1, T2, T3, T4, T5, T6, T7, T8> method, Func<TRet, T1, T2, T3, T4, T5, T6, T7, T8> stub) 
		{ 
			return RegisterStub(method, stub, new StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7, T8>()); 
		}
		 
	}
}
