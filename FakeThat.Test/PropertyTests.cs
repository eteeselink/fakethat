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

        [Test]
        public void StubbedSetterIsCalledWhenSet()
        {
            var fake = new Fake<IPropertyInterface>();
            var obj = fake.Object;

            int latestValue = 0;

            var setterHistory = fake.StubSetter(i => obj.GetSet = i, (int i) => latestValue = i);
            obj.GetSet = 6;

            latestValue.ShouldBe(6);
            setterHistory.CallCount.ShouldBe(1);
            setterHistory.Calls.Single().Value.ShouldBe(6);
        }

        [Test]
        [ExpectedException(typeof(ThatsNotASetterException))]
        public void StubSetterFailsWhenCalled()
        {
            var fake = new Fake<IPropertyInterface>();
            var obj = fake.Object;


            fake.StubSetter(i => { }, (int i) => { });
        }
    }
}
