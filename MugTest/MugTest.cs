using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MugMocks;

namespace MugTest
{
    public interface IAdder
    {
        int AddOne(int i);

        int SomeProperty { get; set;  }
    }

    public interface IChecker
    {
        void CheckFive(int i);
        void PrintSomething();
    }

    public 
        class Subject
    {
        IAdder adder;
        public Subject(IAdder adder)
        {
            this.adder = adder;
        }
        public List<int> CountToTen()
        {
            var list = new List<int>();
            int i = 0;
            while (i != 10)
            {
                list.Add(i);
                i = adder.AddOne(i);
            }
            return list;
        }
    }

    [TestFixture]
    public class SubjectTest
    {
        private Mug mug;

        [SetUp]
        public void SetUp()
        {
            
            mug = new Mug();
        }


        [Test]
        public void CountToTenShouldCountToTen()
        {
            var adder = mug.Mock<IAdder>();
            var subject = new Subject(adder);

            var callCount = 0;
            mug.Stub(adder.AddOne, delegate(int i)
            {
                callCount++;
                return i + 1;
            });

            var numbers = subject.CountToTen();

            Assert.That(callCount, Is.EqualTo(10));
            Assert.That(numbers[6], Is.EqualTo(6));
        }

        [Test]
        public void moo2()
        {   
            var obj = mug.Mock<IAdder>();

            mug.Stub(obj.AddOne, delegate(int i) 
            { 
                return i + 2; 
            });

            Assert.That(obj.AddOne(5), Is.EqualTo(7));

            mug.Stub(obj.AddOne, delegate(int i)
            {
                return i + 3;
            });

            Assert.That(obj.AddOne(5), Is.EqualTo(8));
        }

        [Test]
        public void VoidMethodsWorkToo()
        {
            var obj = mug.Mock<IChecker>();

            bool wasCalled = false;
            mug.Stub(obj.CheckFive, delegate(int i)
            {
                Assert.That(i, Is.EqualTo(5));
                wasCalled = true;
            });

            obj.CheckFive(5);

            Assert.That(wasCalled);

        }

        [Test]
        public void VoidVoidMethodsWorkToo()
        {
            var obj = mug.Mock<IChecker>();

            bool wasCalled = false;
            mug.Stub(obj.PrintSomething, delegate()
            {
                wasCalled = true;
            });

            obj.PrintSomething();

            Assert.That(wasCalled);
        }

        [Test]
        public void SimpleSyntaxWorks()
        {
            var obj = mug.Mock<IAdder>();

            mug.Stub(obj.AddOne, delegate(int i)
            {
                return i + 1;
            });

            Assert.That(obj.AddOne(5), Is.EqualTo(6));
        }

        [Test, ExpectedException(typeof(MethodNotStubbedException))]
        public void MugShouldThrowOnExecutionOfUnstubbedMethods()
        {
            var obj = mug.Mock<IAdder>();
            obj.AddOne(5);
        }

        [Test]
        public void MethodNotStubbedExceptionShouldIncludeTypename()
        {
            try
            {
                var obj = mug.Mock<IAdder>();
                obj.AddOne(5);
                Assert.Fail();
            }
            catch (MethodNotStubbedException e)
            {
                Assert.That(e.Message, Is.StringContaining(typeof(IAdder).Name));
            }
        }

        class DummyAdder : IAdder
        {
            public int AddOne(int i) { return i; }
            public int SomeProperty { get; set; }
        }

        [Test, ExpectedException(typeof(NotAMugObjectException))]
        public void MugShouldThrowOnStubbingUnMockedObject()
        {
            var obj = new DummyAdder();

            mug.Stub(obj.AddOne, delegate(int i)
            {
                return i;
            });
        }

        [Test]
        public void PropertySetAndGetShouldWork()
        {
            var obj = mug.Mock<IAdder>();

            // getter
            mug.StubProperty(() => obj.SomeProperty, () => 5);
            int stubbedVal = obj.SomeProperty;
            Assert.That(stubbedVal, Is.EqualTo(5));

            // setter
            int passedVal = 0;
            mug.StubProperty(() => obj.SomeProperty, (i) => { passedVal = i; });
            obj.SomeProperty = 7;
            Assert.That(passedVal, Is.EqualTo(7));
        }

        [Test]
        [ExpectedException(typeof(MethodNotStubbedException))]
        public void NotStubbedMethodCannotHaveCallsCounted()
        {
            var chk = mug.Mock<IChecker>();
            mug.CountCalls(() => chk.PrintSomething());
        }

        [Test]
        public void CountCallsShouldWork()
        {
            var obj = mug.Mock<IAdder>();

            mug.Stub(obj.AddOne, (int i) =>
            {
                return i + 1;
            });
            obj.AddOne(5);

            int calls = mug.CountCalls((int i) => obj.AddOne(i));
            Assert.That(calls, Is.EqualTo(1));

            obj.AddOne(6);

            calls = mug.CountCalls((int i) => obj.AddOne(i));
            Assert.That(calls, Is.EqualTo(2));

            var chk = mug.Mock<IChecker>();
            mug.Stub(chk.PrintSomething, () => { });
            calls = mug.CountCalls(() => chk.PrintSomething());
            Assert.That(calls, Is.EqualTo(0));

            mug.Stub(chk.CheckFive, (int i) => { });
            calls = mug.CountCalls((int i) => chk.CheckFive(i));
            Assert.That(calls, Is.EqualTo(0));

        }

        [Test]
        public void AdHoc()
        {
            var obj = mug.Mock<IAdder>();
            mug.Stub(obj.AddOne, (int i) =>
            {
                Assert.That(i, Is.LessThan(3));
                return 5;
            });
            try
            {
                obj.AddOne(6);
            }
            catch (Exception)
            { }
        }
    }

    public interface IPiGenerator
    {
        double GeneratePi(int precision);
    }

    public class Circle
    {
        private double radius;
        private IPiGenerator piGen;

        public Circle(IPiGenerator piGen, double radius)
        {
            this.piGen = piGen;
            this.radius = radius;
        }

        public double Circumference
        {
            get
            {
                return 2 * piGen.GeneratePi(3) * radius;
            }
        }
    }

    // NUnit test for a Circle class that uses a PiGenerator instance to ensure that
    // only fresh values used of pi are used (just like with fruit).
    [TestFixture]
    public class CircleTest
    {
        [Test]
        public void TestCircumference() 
        {
            //create a new Mug object that holds mocked objects and methods
            var mug = new Mug();

            // create a mock object for the IPiGenerator interface
            var piGenerator = mug.Mock<IPiGenerator>();

            // we're testing a circle with radius 2.0, passing in the
            // piGenerator Mock object.
            var circle = new Circle(piGenerator, 2.0);

            bool wasCalled = false;

            // stub the Pi Generator with an in-place block of code
            mug.Stub(piGenerator.GeneratePi, delegate(int precision)
            {
                // check validity of argument with standard NUnit assertions
                Assert.That(precision, Is.InRange(2, 3));

                // we manually keep track of whether piGenerator.GeneratePi 
                // was called. Note that a similar trick can be used to
                // count the amount of calls, or to behave different on later
                // calls.
                wasCalled = true;

                // return a sufficiently good approximation of pi
                return 3.14;
            });

            // invoke the Circumference property that we're testing
            double circumference = circle.Circumference;

            // use fancy NUnit features to check that result value is about 4*pi.
            Assert.That(circumference, Is.EqualTo(12.56).Within(.005));

            // ensure that the Circle class really did use the PiGenerator
            Assert.That(wasCalled);
        }
    }
}
