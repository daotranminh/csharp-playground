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
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (Zoo != null) Zoo.Animals.NotifyNameChange(this, value);
                name = value;
            }
        }

        public int Popularity;
        public Zoo Zoo { get; internal set; }

        public Animal(string name, int popularity)
        {
            Name = name;
            Popularity = popularity;
        }
    }

    class AnimalCollection : KeyedCollection<string, Animal>
    {
        Zoo zoo;
        public AnimalCollection(Zoo zoo)
        {
            this.zoo = zoo;
        }

        internal void NotifyNameChange(Animal a, string newName)
        {
            this.ChangeItemKey(a, newName);
        }

        protected override string GetKeyForItem(Animal item)
        {
            return item.Name;
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
