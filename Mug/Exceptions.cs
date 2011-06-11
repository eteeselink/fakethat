using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MugMocks
{
    /// <summary>
    /// Thrown when <see cref="Mug.Stub"/> is called on an object not created with <see cref="Mug.Mock"/>.
    /// </summary>
    public class NotAMugObjectException : Exception
    {
        internal NotAMugObjectException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Thrown when a method on a mocked object is called without it having been registered with <see cref="Mug.Stub"/>.
    /// </summary>
    public class MethodNotStubbedException : Exception
    {
        internal MethodNotStubbedException(string msg) : base(msg) { }
    }
}
