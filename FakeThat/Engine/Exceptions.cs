using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Engine
{
    /// <summary>
    /// Thrown when a method on a faked object is called without it having been registered with <see cref="Fake{T}.Stub"/>.
    /// </summary>
    public class MethodNotStubbedException : Exception
    {
        internal MethodNotStubbedException(string msg) : base(msg) { }
    }
}
