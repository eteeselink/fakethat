using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace FakeThat.Test
{
    [TestFixture]
    public class PropertyTests
    {
        public void StubbedGetterIsCalledWhenGotten()
        {
            int v = 0;

            var fake = new Fake<IPropertyInterface>();
            var obj = fake.Object;
            var getter = fake.StubGetter(() => obj.GetSet, () => v++);

            obj.GetSet.ShouldBe(0);
            obj.GetSet.ShouldBe(1);
            obj.GetSet.ShouldBe(2);
            obj.GetSet.ShouldBe(3);
            v.ShouldBe(4);

            getter.CallCount.ShouldBe(4);
            getter.Calls.Last().ReturnValue.ShouldBe(3);
        }

        public void StubbedSetterIsCalledWhenSet()
        {
            var fake = new Fake<IPropertyInterface>();
            var obj = fake.Object;

            obj.GetSet = fake.StubSetter((int s) => Console.WriteLine(s));

        }
    }
}
