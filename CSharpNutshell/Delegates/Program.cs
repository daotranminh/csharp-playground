using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate int Transformer(int x);
    delegate void TransformerVec(int[] vals);

    class Program
    {
        static void Main(string[] args)
        {
            Transformer t = Square;
            Console.WriteLine(t(3));

            int[] values = { 1, 2, 3 };
            Util.Transform(values, t);

            foreach (int i in values)
                Console.Write(i + " ");
            Console.WriteLine();

            // Multicast delegates
            TransformerVec tv = SquareVec;
            tv += CubeVec;

            tv(values);
            foreach (int i in values)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.ReadLine();
        }

        static int Square(int x) { return x * x; }

        static void SquareVec(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
                vals[i] = vals[i] * vals[i];
        }

        static void CubeVec(int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
                vals[i] = vals[i] * vals[i] * vals[i];
        }
    }

    class Util
    {
        public static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }
    }
}
