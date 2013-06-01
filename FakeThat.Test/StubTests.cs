using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace FakeThat.Test
{
    /// <summary>
    /// These must be the most boring tests I ever wrote.
    /// </summary>
    [TestFixture]
    public class StubTests
    {
        [Test]
        public void ActionsCanBeStubbed()
        {
            int v = 0;
            var fake = new Fake<IBoringInterface>();

            fake.Stub(fake.Object.Action, () => { v++; });
            v.ShouldBe(0);
            fake.Object.Action();
            v.ShouldBe(1);

            fake.Stub(fake.Object.Action, (int i) => { v = i; });
            fake.Object.Action(456);
            v.ShouldBe(456);

            fake.Stub(fake.Object.Action, (int i, string s) => { v = i + int.Parse(s); });
            fake.Object.Action(100, "245");
            v.ShouldBe(345);
        }

        [Test]
        public void FuncsCanBeStubbed()
        {
            int v = 0;
            var fake = new Fake<IBoringInterface>();
            var obj = fake.Object;

            fake.Stub(obj.Func, () => v++.ToString());
            v.ShouldBe(0);
            obj.Func().ShouldBe("0");
            v.ShouldBe(1);

            fake.Stub(obj.Func, (string s) => v += int.Parse(s));
            obj.Func("456789").ShouldBe(456790);
            v.ShouldBe(456790);

            fake.Stub(obj.Func, (int i, string s) => (v += int.Parse(s) - i).ToString());
            obj.Func(20, "10").ShouldBe("456780");
            v.ShouldBe(456780);
        }

        [Test]
        public void CallsCanBeCountedAndContainTheRightArgumentsAndReturnValues()
        {
            int v = 0;
            var fake = new Fake<IBoringInterface>();
            var obj = fake.Object;

            var action = fake.Stub(obj.Action, (int i, string s) => { v++; });
            obj.Action(1, "1");
            obj.Action(2, "2");
            obj.Action(3, "3");

            action.CallCount.ShouldBe(3);
            action.Calls.Count().ShouldBe(3);
            var calls = action.Calls.ToArray();
            calls[0].Arg1.ShouldBe(1);
            calls[0].Arg2.ShouldBe("1");
            calls[1].Arg1.ShouldBe(2);
            calls[1].Arg2.ShouldBe("2");
            calls[2].Arg1.ShouldBe(3);
            calls[2].Arg2.ShouldBe("3");
        }

        [Test]
        public void CallsToFuncsAlsoRecordTheirReturnValues()
        {
            int v = 0;
            var fake = new Fake<IBoringInterface>();
            var obj = fake.Object;

            var action = fake.Stub(obj.Func, (int i, string s) => v++.ToString());
            obj.Func(1, "1");
            obj.Func(2, "2");
            obj.Func(3, "3");

            action.CallCount.ShouldBe(3);
            action.Calls.Count().ShouldBe(3);
            var calls = action.Calls.ToArray();
            calls[0].Arg1.ShouldBe(1);
            calls[0].Arg2.ShouldBe("1");
            calls[1].Arg1.ShouldBe(2);
            calls[1].Arg2.ShouldBe("2");
            calls[2].Arg1.ShouldBe(3);
            calls[2].Arg2.ShouldBe("3");
        }
    }
}
