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

namespace MugMocks
{
    /// <summary>
    /// Wraps a stubbed setter that it not yet tied to a property.
    /// Assign this setter directly to a property of type T to
    /// tie the stubbed setter body to the property.
    /// </summary>
    public class Setter<T>
    {
        private readonly Delegate setter;
        private readonly SetterRegistry registry;

        internal Setter(SetterRegistry registry, Delegate setter)
        {
            this.registry = registry;
            this.setter = setter;
        }

        /// <summary>
        /// Returns default(T). This method has a side-effect of telling Mug about the
        /// setter that was specified when this object was created. This way,
        /// if you assign a Setter[T] to a to-be-stubbed property of type T, Mug will
        /// be able to find the setter back and tie it to the property.
        /// </summary>
        public static implicit operator T(Setter<T> setter)
        {
            setter.registry.RegisterLatestSetter(setter.setter);
            return default(T);
        }
    }
}
