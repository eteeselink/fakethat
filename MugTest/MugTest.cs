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
    }

    public interface IChecker
    {
        void CheckFive(int i);
        void PrintSomething();
    }

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
    class SubjectTest
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
    }
}
