using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Entities;

namespace GraphQLDemo.GraphQL.GraphTypes
{
    public class PortfolioType : ObjectGraphType<Portfolio>
    {
        public PortfolioType(IDependencyResolver resolver)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.Stocks, nullable: true, type:
                typeof(ListGraphType<StockType>)).Description("Stocks");
        }
    }
}