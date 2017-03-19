using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;
            Console.WriteLine(totalLength("hello", "world"));

            int factor = 2;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(3));

            factor++;
            Console.WriteLine(multiplier(3))
;
            Console.ReadLine();
        }
    }
}
