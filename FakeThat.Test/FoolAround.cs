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

#if DEBUG
        public void Moo()
        {
            var fake = Fake.New<IHello>();

            fake.Stub(fake.Hello, (string s) => s + "hi");
            var f = new Fake<IHello>();
            
            Console.WriteLine(fake.Hello("q"));
        }
#endif
    }
}
