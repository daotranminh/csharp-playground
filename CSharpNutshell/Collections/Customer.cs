using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Customer
    {
        public string LastName;
        public string FirstName;

        public Customer(string last, string first)
        {
            LastName = last;
            FirstName = first;
        }
    }

    public class LastFirstEqComparer : EqualityComparer<Customer>
    {
        public override bool Equals(Customer x, Customer y)
            => x.LastName == y.LastName && x.FirstName == y.FirstName;

        public override int GetHashCode(Customer obj)
            => (obj.LastName + " " + obj.FirstName).GetHashCode();
    }
}
