using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Test
{
    public class FoolAround
    {
        public interface IHello
        {
            string Hello(string s);
        }

        public void Moo()
        {
            var fake = new Fake<IHello>();
            var hello = fake.Stub(fake.Object.Hello, (string s) => "Hello " + s);
            Console.WriteLine(fake.Object.Hello("moo"));

            Console.WriteLine(hello.Calls.Single().Arg1);
            Console.WriteLine(hello.CallCount);
        }
    }
}
