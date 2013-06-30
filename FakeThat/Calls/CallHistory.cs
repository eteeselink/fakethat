using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Calls
{
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory : CallHistoryBase<ActionCallHistory.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 0)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 0 arguments");
            }

            var call = new Call();
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1> : CallHistoryBase<ActionCallHistory<T1>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            internal Call(T1 arg1)
            {
				Arg1 = arg1;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 1)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 1 arguments");
            }

            var call = new Call((T1)arguments[0]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2> : CallHistoryBase<ActionCallHistory<T1, T2>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            internal Call(T1 arg1, T2 arg2)
            {
				Arg1 = arg1;
				Arg2 = arg2;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 2)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 2 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2, T3> : CallHistoryBase<ActionCallHistory<T1, T2, T3>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            internal Call(T1 arg1, T2 arg2, T3 arg3)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 3)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 3 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2, T3, T4> : CallHistoryBase<ActionCallHistory<T1, T2, T3, T4>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 4 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2, T3, T4, T5> : CallHistoryBase<ActionCallHistory<T1, T2, T3, T4, T5>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 5)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 5 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2, T3, T4, T5, T6> : CallHistoryBase<ActionCallHistory<T1, T2, T3, T4, T5, T6>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The 6th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T6 Arg6;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				Arg6 = arg6;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 6)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 6 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2, T3, T4, T5, T6, T7> : CallHistoryBase<ActionCallHistory<T1, T2, T3, T4, T5, T6, T7>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The 6th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T6 Arg6;
            /// <summary>
            /// The 7th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T7 Arg7;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				Arg6 = arg6;
				Arg7 = arg7;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 7)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 7 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class ActionCallHistory<T1, T2, T3, T4, T5, T6, T7, T8> : CallHistoryBase<ActionCallHistory<T1, T2, T3, T4, T5, T6, T7, T8>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The 6th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T6 Arg6;
            /// <summary>
            /// The 7th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T7 Arg7;
            /// <summary>
            /// The 8th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T8 Arg8;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				Arg6 = arg6;
				Arg7 = arg7;
				Arg8 = arg8;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 8)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 8 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<TRet> : CallHistoryBase<FuncCallHistory<TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(TRet returnvalue)
            {
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 1)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 1 arguments");
            }

            var call = new Call((TRet)arguments[0]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, TRet> : CallHistoryBase<FuncCallHistory<T1, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, TRet returnvalue)
            {
				Arg1 = arg1;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 2)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 2 arguments");
            }

            var call = new Call((T1)arguments[0], (TRet)arguments[1]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 3)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 3 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (TRet)arguments[2]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, T3, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, T3, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, T3 arg3, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 4 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (TRet)arguments[3]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, T3, T4, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, T3, T4, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 5)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 5 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (TRet)arguments[4]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, T3, T4, T5, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, T3, T4, T5, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 6)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 6 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (TRet)arguments[5]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, T3, T4, T5, T6, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, T3, T4, T5, T6, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The 6th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T6 Arg6;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				Arg6 = arg6;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 7)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 7 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (TRet)arguments[6]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The 6th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T6 Arg6;
            /// <summary>
            /// The 7th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T7 Arg7;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				Arg6 = arg6;
				Arg7 = arg7;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 8)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 8 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (TRet)arguments[7]);
            calls.Add(call);
        } 
    }
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object. The call history
	/// cannot be changed, but it can be cleared by calling <see cref="CallHistoryBase{TCall}.ForgetCalls"/>.
    /// </summary>
    public class FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, T8, TRet> : CallHistoryBase<FuncCallHistory<T1, T2, T3, T4, T5, T6, T7, T8, TRet>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to argumentsand whatever the stub returned.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The 1st argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T1 Arg1;
            /// <summary>
            /// The 2nd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T2 Arg2;
            /// <summary>
            /// The 3rd argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T3 Arg3;
            /// <summary>
            /// The 4th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T4 Arg4;
            /// <summary>
            /// The 5th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T5 Arg5;
            /// <summary>
            /// The 6th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T6 Arg6;
            /// <summary>
            /// The 7th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T7 Arg7;
            /// <summary>
            /// The 8th argument that the software under test called this stubbed method/property with.
            /// </summary>
            public readonly T8 Arg8;
            /// <summary>
            /// The value that the stubbed method/property returned to the software under test
            /// </summary>
            public readonly TRet ReturnValue;
            internal Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, TRet returnvalue)
            {
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
				Arg6 = arg6;
				Arg7 = arg7;
				Arg8 = arg8;
				ReturnValue = returnvalue;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 9)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 9 arguments");
            }

            var call = new Call((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (TRet)arguments[8]);
            calls.Add(call);
        } 
    }
}

