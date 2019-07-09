
using System.Collections.Generic;

namespace GraphQLDemo.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; } =
            new List<Portfolio>();
    }
}
