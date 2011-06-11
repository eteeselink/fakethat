using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.ConsoleRunner;
using System.Reflection;
using MugMocks;

namespace MugTest
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Runner.Main(new string[] { Assembly.GetExecutingAssembly().Location, "/run:MugTest.SubjectTest.AdHoc" });
            
            Console.ReadLine();
        }
    }
}
