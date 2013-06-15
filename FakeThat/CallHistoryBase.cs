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

namespace FakeThat
{
    public abstract class CallHistoryBase
    {
        /// <summary>
        /// Register a call that was successfully completed with this Stubbed[Func/Action]
        /// so that the user may find it back in the `Calls` property. `arguments` consists of
        /// the stubbed operation's return value (if applicable), followed by all argumens used to make the call.
        /// </summary>
        internal abstract void RememberCall(object[] arguments);
    }

    public abstract class CallHistoryBase<TCall> : CallHistoryBase
    {
        protected readonly List<TCall> calls;
        public IEnumerable<TCall> Calls { get { return calls; } }
        public int CallCount { get { return calls.Count; } }

        public CallHistoryBase()
        {
            calls = new List<TCall>();
        }

        public void ForgetCalls()
        {
            calls.Clear();
        }
    }
}
