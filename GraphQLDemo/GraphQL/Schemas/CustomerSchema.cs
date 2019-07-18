using GraphQL;
using GraphQL.Types;
using GraphQLDemo.GraphQL.Mutations;
using GraphQLDemo.GraphQL.Queries;

namespace GraphQLDemo.GraphQL.Schemas
{
    public class CustomerSchema : Schema
    {
        public CustomerSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CustomerQuery>();
            Mutation = resolver.Resolve<CustomerMutation>();
            
        }
    }
}
