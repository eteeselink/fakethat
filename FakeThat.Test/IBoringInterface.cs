using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeThat.Test
{
    public interface IBoringInterface
    {
        void Action();
        void Action(int arg1);
        void Action(int arg1, string arg2);

        string Func();
        int Func(string arg1);
        string Func(int arg1, string arg2);
    }
}
