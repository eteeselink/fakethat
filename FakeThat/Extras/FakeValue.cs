using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Extras
{
    /// <summary>
    /// A marker class, used in `Fake.StubSetter`. Assign a value of this
    /// type to a faked object's setter in `StubSetter`'s first parameter.
    /// </summary>
    public class FakeValue<TProp>
    {
        /// <summary>
        /// Simply returns the default value (null or zero) for TProp.
        /// </summary>
        public static implicit operator TProp(FakeValue<TProp> setter)
        {
            return default(TProp);
        }
    }
}
