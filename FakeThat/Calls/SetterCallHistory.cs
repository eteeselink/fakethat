using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Calls
{
    /// <summary>
    /// Stores a history of all calls made to a certain method or property on a fake object.
    /// </summary>
    public class SetterCallHistory<T1> : CallHistoryBase<SetterCallHistory<T1>.Call>
    {
        /// <summary>
        /// Data related to a single call made to a stubbed method or property. Gives strongly-typed access to arguments.
        /// </summary>
        public struct Call
        {
            /// <summary>
            /// The value that the software under test set this property to.
            /// </summary>
            public readonly T1 Value;
            internal Call(T1 value)
            {
                Value = value;
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
}
