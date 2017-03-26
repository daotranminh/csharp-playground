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
        public Zoo Zoo { get; internal set; }

        public Animal(string name, int popularity)
        {
            Name = name;
            Popularity = popularity;
        }
    }

    class AnimalCollection : Collection<Animal>
    {
        Zoo zoo;
        public AnimalCollection(Zoo zoo)
        {
            this.zoo = zoo;
        }

        protected override void InsertItem(int index, Animal item)
        {
            base.InsertItem(index, item);
            item.Zoo = zoo;
        }

        protected override void SetItem(int index, Animal item)
        {
            base.SetItem(index, item);
            item.Zoo = zoo;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Zoo = null;
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach (Animal a in this) a.Zoo = null;
            base.ClearItems();
        }
    }

    class Zoo
    {
        public string Name { get; set; }
        public readonly AnimalCollection Animals;
        public Zoo(string name)
        {
            Name = name;
            Animals = new AnimalCollection(this);
        }
    }
}
