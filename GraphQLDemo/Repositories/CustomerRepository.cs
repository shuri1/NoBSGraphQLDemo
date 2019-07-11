using System.Collections.Generic;
using System.Linq;
using GraphQLDemo.Entities;
using GraphQLDemo.Repositories.Interfaces;

namespace GraphQLDemo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly List<Customer> _customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Larry",
                Address = "1234 Anywhere street",
                City = "Your town",
                State = "IL",
                Zipcode = "60123",
                Portfolios = new List<Portfolio>
                {
                    new Portfolio
                    {
                        Id = 1, Name = "Retirement", Value = 234.45,
                        Stocks = new List<Stock>
                        {
                            new Stock { Id = 1, LastPrice = 22.5, Name = "MSFT"},
                            new Stock { Id = 2, LastPrice = 122.5, Name = "AMZN"},
                            new Stock { Id = 3, LastPrice = 1122.5, Name = "FB"},
                            new Stock { Id = 4, LastPrice = 222.5, Name = "TWITTER"}
                        }
                    },
                    new Portfolio { Id = 2, Name = "Investment", Value = 2234.45},
                }
            },
            new Customer
            {
                Id = 2,
                Name = "Joe",
                Address = "1234 Another street",
                City = "Your other town",
                State = "IL",
                Zipcode = "60124"
            },
            new Customer
            {
                Id = 3,
                Name = "Steve",
                Address = "12 Nowhere street",
                City = "Twilight zone",
                State = "IL",
                Zipcode = "60124"
            },
        };

        public List<Customer> GetAll() => _customers;

        public Customer GetCustomerById(int id) => _customers.FirstOrDefault(c => c.Id == id);
        public Customer AddCustomer(Customer customer)
        {
            _customers.Add(customer);
             return customer;
        }
    }
}