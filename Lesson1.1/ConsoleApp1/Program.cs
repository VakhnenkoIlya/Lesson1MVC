using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           Stopwatch sw = new Stopwatch();
            sw.Restart();
            Console.WriteLine($"{sw.Elapsed}");
            Console.ReadLine();
            var date1 = new DateTime();
            Console.WriteLine($"{date1.Second}");
        }
    }
}

