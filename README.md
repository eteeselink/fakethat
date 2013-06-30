Ridiculously simple mocking for C#
==================================

[![Build Status](https://travis-ci.org/eteeselink/fakethat.png)](https://travis-ci.org/eteeselink/fakethat)

``` c#
// Create a fake Death Star
var fakeStar = new Fake<IDeathStar>();

// Set up the fake so that a call to Shoot(Planet) always misses
var shootCalls = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) => "Haha, missed!");

// give the fake Death Star to a real Vader (the class we wish to test)
var vader = new Vader(fakeStar.Object);
vader.GetAngry();

// Check whether our stubbed method was indeed called. We can use plain LINQ and
// any preferred unit testing / assertion library. No need to learn any special 
// mocking-framework assertion/verification syntax.
shootCalls.Count.ShouldBe(2);

// We have full access to the call history.
shootCalls[0].Arg1.Name.ShouldBe("Alderaan");
shootCalls[0].ReturnValue.ShouldContain("Haha,");
shootCalls.Last().Arg1.Name.ShouldBe("Naboo");
```
<sup>Fancy `Should*` assertion methods courtesy of the excellent [Shouldly](http://shouldly.github.io/) library. Note that you don't at all need Shouldly to use Fake That.</sup>

Description
-----------

Fake That is a simplistic mocking library for C# 
that allows you to stub methods on mock objects with delegates or lambda expressions. 
This means that unlike with other mocking frameworks, 
you just write snippets of code in which you check whether the stubbed method has been called with the expected arguments and return appropriate values. 
It's like writing a stub class, except without the boilerplate.

Though heavily inspired by [Moq](http://code.google.com/p/moq/) and [FakeItEasy](https://github.com/FakeItEasy/FakeItEasy), 
Fake That is different in that it is comparably low on weird syntax.
Fake That favours plain C# code and .NET data structures over "almost-like-English" fluent APIs that *just* can't do what you want it to do right now.

For example:

### Return values and validate arguments with plain C# 

Other libraries have extensive fluent syntax for specifying that a method may be called
only with these and these arguments, and should return such and such a value. 
In Fake That, you do this in a lambda expression that contains plain old C# code.

``` c#
var fakeStar = new Fake<IDeathStar>();

var shootCalls = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) =>
{
    // Validate arguments using normal C# code
    planet.ShouldNotBe(null);

    // Make the return value depend on the arguments
    return (planet.Name.Contains("oo")) ? "BOOM!" : "Haha, missed!";
});
```

Note that you should specify the types of all arguments in the lambda expression (e.g. `(Planet planet) => ..` and not just `planet => ..`).
This is because C# can't figure out which overload of `Shoot` you want to stub without those parameter types
(even when there's no overloads).

### Full, strongly-typed, access to call history

Every `Stub` call returns a `CallHistory` object with an IEnumerable `Calls` property.

``` c#
var shootCalls = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) => "Haha, missed!");

// .. call code that would call fakeStar.Object.Shoot()

shootCalls
	.Where(call => call.Arg1 == "Alderaan")
	.All(call => call.ReturnValue.Contains("Haha,")
	.ShouldBe(true);
```

### Stub property getters and setters just the same

Getters:

``` c#
var isArmedCalls = fakeStar.StubGetter(() => fakeStar.Object.IsArmed, (bool armed) => true);

vader.GetAngry();

isArmedCalls.Count.ShouldBe(1);
```

Setters:

``` c#
var targetCalls = fakeStar.StubSetter(v => fakeStar.Object.Target = v, (Planet planet) => 
{
    planet.Name.ShouldBe("Alderaan");
});

vader.GetAngry();

targetCalls.Count.ShouldBe(1);
```


Installation
------------

### Getting the binaries

Currently: Compile from source with a single `xbuild FakeThat.sln` on the command line (install Mono first).
The resulting FakeThat.dll will work on both Mono and .NET.
`FakeThat.sln` is a Visual Studio 2010 solution, and I expect that it also works in MonoDevelop.

TODO:
* Download binaries
* Install from NuGet

### Supported platforms

* .NET 4 and higher
* Mono 2.8 and higher

.NET 3.5 support is currently lacking, 
but could be provided relatively easily with some conditional compilation. 
Please file an [issue](./issues) if you need this (or a pull request, of course).

I have no clue to what extent all the half-assed .NET frameworks 
(Silverlight, Windows Phone, Win RT, Client Profile) support Fake That.
If you find out, please [let me know](./issues). Thanks!


Background
---------
I wrote Fake That because other C# mocking libraries made my upper back itch, 
and that's a very difficult place to scratch. 

Some design goals include:
* Be simple enough to require very little documentation
* Fully typechecked: no strings for method names and all that
* Comfortably stay outside the "Mocks vs Stubs" discussion by allowing any usage patten you prefer.

Please let me know if you think that I managed.


Credits
-------

Fake That was written by Egbert Teeselink. It uses the excellent <a href="http://www.castleproject.org/dynamicproxy/index.html">Castle DynamicProxy</a> to do all the hard object-generating work.

Fake That is released under the <a href="http://creativecommons.org/licenses/MIT/">MIT License</a>.

Thanks to [Travis CI]((https://travis-ci.org/eteeselink/fakethat) for a free build server, and to [danlimerick](http://danlimerick.wordpress.com/2013/02/03/build-your-open-source-net-project-on-travis-ci/) 
for a guide on how to use it for (not officially supported) .NET/Mono code.
