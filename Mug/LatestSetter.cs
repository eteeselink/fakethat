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
    /// Encapsulates a setter object that is about to be linked to a property set method.
    /// </summary>
    internal class SetterRegistry
    {
        private Delegate latestSetter;

        public bool HasLatestSetter()
        {
            return latestSetter != null;
        }
        public Delegate UseLatestSetter()
        {
            var setter = latestSetter;
            latestSetter = null;
            return setter;
        }
        public void RegisterLatestSetter(Delegate setter)
        {
            latestSetter = setter;
        }
    }
}
