Ridiculously simple mocking for .NET
====================================

[![Build Status](https://travis-ci.org/eteeselink/fakethat.png)](https://travis-ci.org/eteeselink/fakethat)

``` c#
// Create a fake Death Star
var fakeStar = new Fake<IDeathStar>();

// Set up the fake so that a call to Shoot(Planet) always misses
var shoot = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) => "Haha, missed!");

// give the fake Death Star to a real Vader (the class we wish to test)
var vader = new Vader(fakeStar.Object);
vader.GetAngry();

// Check whether our stubbed method was indeed called. We can use plain LINQ and
// any preferred unit testing / assertion library. No need to learn any special 
// mocking-framework assertion/verification syntax.
shoot.CallCount.ShouldBe(2);

// We have full access to the call history.
shoot.Calls.First().Arg1.Name.ShouldBe("Alderaan");
shoot.Calls.First().ReturnValue.ShouldContain("Haha,");
shoot.Calls.Last().Arg1.Name.ShouldBe("Naboo");
```
<sup>Fancy `Should*` assertion methods courtesy of the excellent [Shouldly](http://shouldly.github.io/) library</sup>

Description
-----------

Fake That is a simplistic mocking library for .NET that allows you to stub methods on mock objects with delegates or lambda expressions. 
This means that unlike with other mocking frameworks, 
you just write snippets of code in which you check whether the stubbed method has been called with the expected arguments and return appropriate values. 
It's like writing a stub class, except without the boilerplate.

Though heavily inspired by [Moq](http://code.google.com/p/moq/) and [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy), 
Fake That is different in that it is comparably low on weird syntax.
Fake That favours plain C# code and .NET data structures over "almost-like-English" fluent APIs that *just* can't do what you want it to do right now.

For example:

### Validate method arguments, set up return values and side effects, with plain C# 

Other libraries have extensive fluent syntax for specifying that a method may be called
only with these and these arguments, and should return such and such a value. 
In Fake That, you do this in a lambda expression that contains plain old C# code.

``` c#
var fakeStar = new Fake<IDeathStar>();

var shoot = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) =>
{
    // Validate arguments using normal C# code
    planet.ShouldNotBe(null);

    // Make the return value depend on the arguments
    return (planet.Name.Contains("oo")) ? "BOOM!" : "Haha, missed!";
});
```

### Full, strongly-typed, access to call history

Every `Stub` call returns `CallHistory` object with an IEnumerable `Calls` property.

``` c#
var shoot = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) => "Haha, missed!");

// .. call code that would call fakeStar.Object.Shoot()

shoot.Calls
	.Where(call => call.Arg1 == "Alderaan")
	.All(call => call.ReturnValue.Contains("Haha,")
	.ShouldBe(true);
```

### Stub property getters and setters just the same

``` c#
var isArmed = fakeStar.StubGetter(() => fakeStar.Object.IsArmed, (bool armed) => true);

vader.GetAngry();

isArmed.CallCount.ShouldBe(1);
```

``` c#
var target = fakeStar.StubSetter(v => fakeStar.Object.Target = v, (Planet planet) => 
{
    planet.Name.ShouldBe("Alderaan");
});

vader.GetAngry();

target.CallCount.ShouldBe(1);
```



OLD README BELOW
================


Features
--------

  * Fully typechecked object mocking
  * Use assertions and matchers from your favourite unit testing framework inside the methods of your mock object
  * No reference manual; there are only two methods
  * Works on .NET 3.5 and higher. Maybe also 2.0, but I haven't figured that out yet.
  * Comfortably stays outside the "Mocks vs Stubs" discussion by using both terms in its two-word API, probably incorrectly.

Rationale
---------
I wrote Mug because other C# mocking libraries made my upper back itch, and that's a very difficult place to scratch. Here's what makes Mug different:

### Delegates over fluent interfaces
As you can see from the somewhat silly example above, Mug does not have any fancy "fluent object" syntax that allow you to check that a method has been called five times or that generate method logic for you. Mug also does not have an "Advanced Features" manual page that teach you how to use "amazing features that allow you to *make the return value depend on an argument!*". Making return values depend on arguments is exactly what they invented programming languages for, so let's use that!

### Fully type checked
Nevertheless, mocking with Mug is fully type checked; you cannot stub methods that don't exist, or write stubs that accept or return the wrong types. If you change the signature of a method that is mocked somewhere and don't update the tests accordingly, the tests will fail to compile. This is important, because it means that you get direct feedback from your environment while writing *and* maintaining your code.

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
 * Ditto for Silverlight and for CLR languages other than C#
 * Brag about Mug on the interwebs
 
Help with any of the above (or any other help you think I might need) is much appreciated! I promise that I'll rewrite this page in first person plural upon significant contributions. Imagine the glory!

Credits
-------

Mug was written by Egbert Teeselink. It uses the excellent <a href="http://www.castleproject.org/dynamicproxy/index.html">Castle DynamicProxy</a> to do all the hard object-generating work.

Mug is released under the <a href="http://creativecommons.org/licenses/MIT/">MIT License</a>.

Thanks to Travis-CI for a free build server, and to [danlimerick](http://danlimerick.wordpress.com/2013/02/03/build-your-open-source-net-project-on-travis-ci/) 
for a guide on how to use it for (not officially supported) .NET/Mono code.
