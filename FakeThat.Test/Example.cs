using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Shouldly;

namespace FakeThat.Test
{
    public class Planet
    {
        public string Name { get; set; }
    }
    public interface IDeathStar
    {
        string Shoot(Planet planet);
    }

    public class Vader
    {
        private readonly IDeathStar star;
        public Vader(IDeathStar star) 
        { 
            this.star = star;
        }

        public void GetAngry()
        {
            var result = star.Shoot(new Planet { Name = "Alderaan" });
            if (result != "BOOM!")
            {
                result = star.Shoot(new Planet { Name = "Naboo" });
                if (result != "BOOM!")
                {
                    Console.WriteLine("Noooooo!");
                }
            }
        }
    }

    [TestFixture]
    public class Example
    {
        [Test]
        public void SimpleMethodStub()
        {
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
        }

        [Test]
        public void AssertArguments()
        {
            var fakeStar = new Fake<IDeathStar>();

            var shoot = fakeStar.Stub(fakeStar.Object.Shoot, (Planet planet) =>
            {
                // Validate arguments using normal C# code
                planet.ShouldNotBe(null);

                // Make the return value depend on the arguments
                return (planet.Name.Contains("oo")) ? "BOOM!" : "Haha, missed!";
            });

            
        }
    }
}
