using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Animal
    {
        public string Name;
        public int Popularity;

        public Animal(string name, int popularity)
        {
            Name = name;
            Popularity = popularity;
        }
    }

    class AnimalCollection : Collection<Animal>
    { }

    class Zoo
    {
        public readonly AnimalCollection Animals = new AnimalCollection();
    }
}
