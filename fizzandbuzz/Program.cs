using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FizzAndBuzzLib;

namespace fizzandbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fizzbuzz = new FizzBuzz(300);
            IEnumerable<String> results = from fb in fizzbuzz select fb; 
            foreach (String line in results)
            {
                System.Console.WriteLine(line);
            }
            System.Console.ReadKey();
        }

    }
}
