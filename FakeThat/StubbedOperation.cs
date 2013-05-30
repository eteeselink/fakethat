using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat
{
    public class StubbedAction : StubbedOperationBase<StubbedAction.Call>
    {
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
    public class StubbedAction<T1> : StubbedOperationBase<StubbedAction<T1>.Call>
    {
        public struct Call
        {
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
    public class StubbedAction<T1, T2> : StubbedOperationBase<StubbedAction<T1, T2>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
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
    public class StubbedAction<T1, T2, T3> : StubbedOperationBase<StubbedAction<T1, T2, T3>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
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
    public class StubbedAction<T1, T2, T3, T4> : StubbedOperationBase<StubbedAction<T1, T2, T3, T4>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
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
    public class StubbedAction<T1, T2, T3, T4, T5> : StubbedOperationBase<StubbedAction<T1, T2, T3, T4, T5>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
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
    public class StubbedAction<T1, T2, T3, T4, T5, T6> : StubbedOperationBase<StubbedAction<T1, T2, T3, T4, T5, T6>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
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
    public class StubbedAction<T1, T2, T3, T4, T5, T6, T7> : StubbedOperationBase<StubbedAction<T1, T2, T3, T4, T5, T6, T7>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
            public readonly T6 Arg6;
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
    public class StubbedAction<T1, T2, T3, T4, T5, T6, T7, T8> : StubbedOperationBase<StubbedAction<T1, T2, T3, T4, T5, T6, T7, T8>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
            public readonly T6 Arg6;
            public readonly T7 Arg7;
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
    public class StubbedFunc<TRet> : StubbedOperationBase<StubbedFunc<TRet>.Call>
    {
        public struct Call
        {
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
    public class StubbedFunc<TRet, T1> : StubbedOperationBase<StubbedFunc<TRet, T1>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            internal Call(TRet returnvalue, T1 arg1)
            {
				ReturnValue = returnvalue;
				Arg1 = arg1;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 2)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 2 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2> : StubbedOperationBase<StubbedFunc<TRet, T1, T2>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2)
            {
				ReturnValue = returnvalue;
				Arg1 = arg1;
				Arg2 = arg2;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 3)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 3 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2, T3> : StubbedOperationBase<StubbedFunc<TRet, T1, T2, T3>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2, T3 arg3)
            {
				ReturnValue = returnvalue;
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 4 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2], (T3)arguments[3]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2, T3, T4> : StubbedOperationBase<StubbedFunc<TRet, T1, T2, T3, T4>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            {
				ReturnValue = returnvalue;
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 5)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 5 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2], (T3)arguments[3], (T4)arguments[4]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2, T3, T4, T5> : StubbedOperationBase<StubbedFunc<TRet, T1, T2, T3, T4, T5>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            {
				ReturnValue = returnvalue;
				Arg1 = arg1;
				Arg2 = arg2;
				Arg3 = arg3;
				Arg4 = arg4;
				Arg5 = arg5;
            }
        }

        internal override void RememberCall(object[] arguments)
        {
            if (arguments.Length != 6)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 6 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2], (T3)arguments[3], (T4)arguments[4], (T5)arguments[5]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2, T3, T4, T5, T6> : StubbedOperationBase<StubbedFunc<TRet, T1, T2, T3, T4, T5, T6>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
            public readonly T6 Arg6;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            {
				ReturnValue = returnvalue;
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
            if (arguments.Length != 7)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 7 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2], (T3)arguments[3], (T4)arguments[4], (T5)arguments[5], (T6)arguments[6]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7> : StubbedOperationBase<StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
            public readonly T6 Arg6;
            public readonly T7 Arg7;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            {
				ReturnValue = returnvalue;
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
            if (arguments.Length != 8)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 8 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2], (T3)arguments[3], (T4)arguments[4], (T5)arguments[5], (T6)arguments[6], (T7)arguments[7]);
            calls.Add(call);
        } 
    }
    public class StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7, T8> : StubbedOperationBase<StubbedFunc<TRet, T1, T2, T3, T4, T5, T6, T7, T8>.Call>
    {
        public struct Call
        {
            public readonly TRet ReturnValue;
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly T3 Arg3;
            public readonly T4 Arg4;
            public readonly T5 Arg5;
            public readonly T6 Arg6;
            public readonly T7 Arg7;
            public readonly T8 Arg8;
            internal Call(TRet returnvalue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            {
				ReturnValue = returnvalue;
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
            if (arguments.Length != 9)
            {
                throw new ArgumentException("Internal FakeThat error: expected exactly 9 arguments");
            }

            var call = new Call((TRet)arguments[0], (T1)arguments[1], (T2)arguments[2], (T3)arguments[3], (T4)arguments[4], (T5)arguments[5], (T6)arguments[6], (T7)arguments[7], (T8)arguments[8]);
            calls.Add(call);
        } 
    }
}

