using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace FakeThat.Engine
{
    // stolen from http://stackoverflow.com/a/8946825
    internal class IdentityEqualityComparer<T> : IEqualityComparer<T>
        where T : class
    {
        public int GetHashCode(T value)
        {
            return RuntimeHelpers.GetHashCode(value);
        }

        public bool Equals(T left, T right)
        {
            return left == right; // Reference identity comparison
        }
    }
}
