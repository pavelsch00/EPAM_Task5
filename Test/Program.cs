using System;
using Task2;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var human = new Human();

            Console.WriteLine(human.Version.Major);
        }
    }
}
