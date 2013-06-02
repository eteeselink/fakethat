using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat
{
    public class StubbedSetter<TProp> : StubbedAction<TProp>
    {
        internal bool Assignable = false;

        /// <summary>
        /// Used to tie a newly created setter to a property on a fake object.
        /// </summary>
        public static implicit operator TProp(StubbedSetter<TProp> setter)
        {
            setter.Assignable = true;
            return default(TProp);
        }
    }
}
