using System.Linq;
using GraphQL.Types;
using GraphQLDemo.Entities;

namespace GraphQLDemo.GraphQL.GraphTypes
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(cust => cust.Id);
            Field(cust => cust.Name);
            Field(cust => cust.City);
            Field(cust => cust.Address);
            Field(cust => cust.State);
            Field(cust => cust.Zipcode);
            Field(x => x.Portfolios, nullable: true, type: typeof(ListGraphType<PortfolioType>)).Description("Portfolios");
            Field<PortfolioType>("portfolio",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => context.Source.Portfolios.FirstOrDefault(port => port.Id == context.GetArgument<int>("id")));
        }
    }
}
