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
            void VoidMethod();
            int Three { set; }
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
        public void Maa()
        {
            var fake = new Fake<IHello>();
            fake.StubSetter<int>(v => fake.Object.Three = v);
            var c = fake.Stub<string, string>(fake.Object.Hello);
            var d = fake.Stub(fake.Object.VoidMethod);

            fake.Object.Hello("a");
            fake.Object.VoidMethod();
            Console.WriteLine(d.CallCount);
        }
    }
}
