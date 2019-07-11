using GraphQL.Types;
using GraphQLDemo.Entities;
using GraphQLDemo.GraphQL.GraphTypes;
using GraphQLDemo.Repositories.Interfaces;

namespace GraphQLDemo.GraphQL.Mutations
{
    public class CustomerMutation : ObjectGraphType<Customer>
    {
        public CustomerMutation(ICustomerRepository customerRepository)
        {

                Field<CustomerType>(
                    "createCustomer",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }
                    ),
                    resolve: context =>
                    {
                        var customer= context.GetArgument<Customer>("customer");
                        return customerRepository.AddCustomer(customer);
                    });
            
        }

    }
}
