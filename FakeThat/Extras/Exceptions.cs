﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Extras
{
    /// <summary>
    /// Thrown when a method on a faked object is called without it having been registered with `Stub(..)`.
    /// </summary>
    public class MethodNotStubbedException : Exception
    {
        internal MethodNotStubbedException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Thrown when the body of the setter action passed to `StubSetter(..)` is
    /// not actually a setter assignment.
    /// </summary>
    public class ThatsNotASetterException : Exception
    {
        internal ThatsNotASetterException() : base("Please pass an expression of the form `v => fake.Object.SomeSetter = v` to `StubSetter`") { }
    }
}
