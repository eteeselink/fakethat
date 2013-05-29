#region fileHeader
// ----------------------------------------------------------------------------
// 
//  (c) Copyright Fleetlogic B.V., The Netherlands, 2013
//  All rights reserved
// 
// ----------------------------------------------------------------------------
// 
//   $HeadURL: $
//   $Id: $
// 
// ----------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MugMocks
{
    public abstract class StubbedFuncBase<TCall>
    {
        protected readonly List<TCall> calls;
        public IEnumerable<TCall> Calls { get { return calls; } }
        public int CallCount { get { return calls.Count; } }

        public StubbedFuncBase()
        {
            calls = new List<TCall>();
        }

        public void ForgetCalls()
        {
            calls.Clear();
        }
    }

    public class StubbedFunc<TRet, T1, T2> : StubbedFuncBase<StubbedFunc<TRet, T1, T2>.Call>
    {
        public struct Call
        {
            public readonly T1 Arg1;
            public readonly T2 Arg2;
            public readonly TRet ReturnValue;

            internal Call(TRet returnValue, T1 arg1, T2 arg2)
            {
                ReturnValue = returnValue;
                Arg1 = arg1;
                Arg2 = arg2;
            }
        }

        internal void AddCall(object retval, object[] arguments)
        {
            if (arguments.Length != 2)
            {
                throw new ArgumentException("Internal Mug error: expected exactly 2 arguments");
            }

            var call = new Call(
                (TRet)retval,
                (T1)arguments[0],
                (T2)arguments[1]
            );

            calls.Add(call);
        }
    }
}
