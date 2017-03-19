using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Marry", "Lay" };
            IEnumerable<string> filteredNames = names.Where(n => n.Length >= 4);

            filteredNames = names.Where(n => n.Contains("a"));

            IEnumerable<string> query = names
                .Where(n => n.Contains("a"))
                .OrderBy(n => n.Length)
                .Select(n => n.ToUpper());
            
            foreach (string n in query)
                Console.WriteLine(n);

            Console.ReadLine();
        }
    }
}
