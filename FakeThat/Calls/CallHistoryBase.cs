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
    public abstract class CallHistoryBase<TCall> : CallHistoryBase, IEnumerable<TCall>
    {
        internal readonly List<TCall> calls;

        /// <summary>
        /// Gets the number of calls recorded up until now.
        /// </summary>
        public int Count { get { return calls.Count; } }

        /// <summary>
        /// Get the `index`th call made since the fake object was created.
        /// </summary>
        public TCall this[int index]
        {
            get
            {
                return calls[index];
            }
        }

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

        /// <summary>
        /// Returns an enumerator that iterates through the call history.
        /// </summary>
        public IEnumerator<TCall> GetEnumerator()
        {
            return calls.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the call history.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return calls.GetEnumerator();
        }
    }
}
