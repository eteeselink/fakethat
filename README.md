Ridiculously simple mocking for .NET
====================================

Mug is a simplistic mocking library for .NET that allows you to stub methods on mock objects with delegates. This means that unlike with other mocking frameworks, you just write snippets of code in which you check whether the stubbed method has been called with the expected parameters and from which you return appropriate values. It's like writing a stub class, except right in the body of your test. For example:

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

That's it. Create a mock object and stub its methods with in-place delegates.

Features
--------

  * Fully typechecked object mocking
  * Use assertions and matchers from your favourite unit testing framework inside the methods of your mock object
  * No reference manual; there are only two methods
  * Sure to work on .NET 3.5 and higher. Maybe also 2.0, but I haven't figured that out yet.
  * Comfortably stays outside the "Mocks vs Stubs" discussion by using both terms in its two-word API, probably incorrectly.

Rationale
---------

### Delegates over fluent interfaces
As you can see from the somewhat silly example above, Mug does not have any fancy "fluent object" syntax that allow you to check that a method has been called five times or that generate method logic for you. Mug also does not have an "Advanced Features" manual page that teach you how to use "amazing features that allow you to *make the return value depend on an argument!*". Making return values depend on arguments is exactly what they invented programming languages for, so let's use that!

### Fully type checked
Nevertheless, mocking with Mug is fully type checked; you cannot stub methods that don't exist, or write stubs that accept or return the wrong values. If you change the signature of a method that is mocked somewhere and don't update the tests accordingly, the tests will fail to compile. This is important, because it means that you get direct feedback from your environment while writing *and* maintaining your code.

### Readable test code over fancy expectation matching
I think that there is no additional value in using a mocking framework to count how often a method was called or to make assertions on the values that were passed. Unit testing frameworks are already very good at that, so why would I want to learn the slightly-different syntax of yet another framework that can do the same, but now in mocked objects? With Mug, instead of `verifyingThatAllExpectationsHaveBeenMet()`, you just assert in-place, you count the method calls yourself and afterwards assert that what you expected happened. This makes for readable tests that can be understood even by people entirely unfamiliar with Mug.

### Truly simple
The above example demonstrates all of Mug's features; there are no more. I have not yet found a use for more.

FAQ
---

 - Can I redefine stubbed methods halfway my test?
 - That delegate syntax makes me feel like it's 2005 all over. Can I use lambda expressions?
 - Can I use this in commercial environments?
 - What's a 3-letter affirmative that starts with a "y"?
 
Todo
----

 * Add support for mocking classes and not just interfaces
 * Add support for mocking properties and not just methods
 * Figure out whether Mug works on .NET 2.0 and why not
 * Brag about Mug on the interwebs
 
Credits
-------

Mug was written by Egbert Teeselink. It uses the excellent <a href="http://www.castleproject.org/dynamicproxy/index.html">Castle DynamicProxy</a> to do all the hard object-generating work.

Mug is released under the <a href="http://creativecommons.org/licenses/MIT/">MIT License</a>.

