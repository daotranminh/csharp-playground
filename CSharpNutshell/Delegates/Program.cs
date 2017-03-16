using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    // Basic part
    delegate int Transformer(int x);
    delegate void TransformerVec(int[] vals);

    // More realistic multicast delegate example
    delegate void ProgressReporter(int percentCompleted);

    class Program
    {
        static void Main(string[] args)
        {
            // Basic delegates
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

            // More realistic multicast delegate example
            //ProgressReporter p = WriteProgressToConsole;
            Util util = new Util();
            ProgressReporter p = util.InstanceProgress;
            p += WriteProgressToFile;
            Util.HardWork(p);

            Console.ReadLine();
        }

        // Basic part
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

        // More realistic multicast delegate example
        static void WriteProgressToConsole(int percentCompleted)
        {
            Console.WriteLine(percentCompleted);
        }

        static void WriteProgressToFile(int percentCompleted)
        {
            System.IO.File.WriteAllText("progress.txt", percentCompleted.ToString());
        }
    }

    class Util
    {
        public static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }

        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10);                           // Invoke delegate
                System.Threading.Thread.Sleep(100);  // Simulate hardwork
            }
        }

        public void InstanceProgress(int percentCompleted)
        {
            Console.WriteLine(percentCompleted);
        }

    }
}
