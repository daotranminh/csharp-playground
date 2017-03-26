using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection1 mc1 = new MyCollection1();
            IEnumerator ie1 = mc1.GetEnumerator();

            while (ie1.MoveNext()) Console.WriteLine(ie1.Current);
            Console.WriteLine();

            MyGenCollection1 mgc1 = new MyGenCollection1();
            IEnumerator<int> ige1 = mgc1.GetEnumerator();

            while (ige1.MoveNext()) Console.WriteLine(ige1.Current);
            Console.WriteLine();

            MyIntList ml = new MyIntList();
            IEnumerator ie2 = ml.GetEnumerator();

            while (ie2.MoveNext()) Console.WriteLine(ie2.Current);
            Console.WriteLine();

            Zoo zoo = new Zoo("Vienna");
            zoo.Animals.Add(new Animal("Kangoroo", 10));
            zoo.Animals.Add(new Animal("Mr Sea Lion", 20));

            foreach (Animal a in zoo.Animals)
                Console.WriteLine(a.Name + " " + a.Popularity.ToString() + " " + a.Zoo.Name);

            Console.ReadLine();
        }
    }
}
