using System;
using System.Collections.Generic;
using GraphQLDemo.Entities;

namespace GraphQLDemo.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int id);
        Customer AddCustomer(Customer customer);
    }
}
      