﻿using System;
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

            query =
                from    n in names
                where   n.Contains("a")
                orderby n.Length
                select  n.ToUpper();

            PrintResult(query);

            // subqueries
            string[] musos =
                { "David Gilmour", "Roger Waters", "Right Wright", "Nick Mason" };

            IEnumerable<string> query2 =
                musos.OrderBy(m => m.Split().Last());
            PrintResult(query2);
            
            IEnumerable<string> query3 = names
                .Where(n => n.Length == names.OrderBy(n2 => n2.Length)
                                             .Select (n2 => n2.Length).First());

            query3 =
                from n in names
                where n.Length ==
                        (from    n2 in names
                         orderby n2.Length
                         select  n2.Length).First()
                select n;

            PrintResult(query3);

            Console.ReadLine();
        }

        static void PrintResult(IEnumerable<string> result)
        {
            foreach (string r in result)
                Console.WriteLine(r);

            Console.WriteLine();
        }
    }
}
