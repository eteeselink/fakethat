using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;
using FakeThat.Engine;

namespace FakeThat.Test
{
    [TestFixture]
    public class PropertyLambdaTests
    {
        [Test]
        public void PropertyLambdaCanReadAPropertyNameFromALambda()
        {
            IPropertyInterface obj = null;
            var lambda = PropertyLambda<IPropertyInterface>.Create(() => obj.GetSet);
            lambda.Getter.Name.ShouldBe("get_GetSet");
        }
    }
}
