using System;
using System.Threading;

namespace test_debug
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.Out.WriteLine("Test");
                Thread.Sleep(1000);

            }
        }
    }
}
