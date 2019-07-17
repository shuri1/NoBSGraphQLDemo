using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLClient.Entities
{
    public class Data
    {
        public List<Customer> Customers { get; set; }
    }

    public class RootObject
    {
        public Data Data { get; set; }
    }
}


