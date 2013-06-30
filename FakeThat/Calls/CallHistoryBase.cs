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

namespace FakeThat.Calls
{
    /// <summary>
    /// Base class for all call history objects. Only used internally.
    /// </summary>
    public abstract class CallHistoryBase
    {
        /// <summary>
        /// Register a call that was successfully completed with this Stubbed[Func/Action]
        /// so that the user may find it back in the `Calls` property. `arguments` consists of
        /// the stubbed operation's return value (if applicable), followed by all argumens used to make the call.
        /// </summary>
        internal abstract void RememberCall(object[] arguments);
    }

    /// <summary>
    /// Base class for all call history objects. Only used internally.
    /// </summary>
    public abstract class CallHistoryBase<TCall> : CallHistoryBase //, IEnumerable<TCall>
    {
        internal readonly List<TCall> calls;

        /// <summary>
        /// A history of all calls made to this method/property up until now. 
        /// Clear the history with <see cref="ForgetCalls"/>.
        /// The call history is plain old (immutable) C# data. You can query it with LINQ,
        /// copy it around, do with it whatever pleases you.
        /// </summary>
        public IEnumerable<TCall> Calls { get { return calls; } }

        /// <summary>
        /// Shortcut property for `Calls.Count()`.
        /// </summary>
        public int CallCount { get { return calls.Count; } }

        internal CallHistoryBase()
        {
            calls = new List<TCall>();
        }
        
        /// <summary>
        /// Clear the call history. 
        /// </summary>
        public void ForgetCalls()
        {
            calls.Clear();
        }
    }
}
