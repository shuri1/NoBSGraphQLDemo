using GraphQL.Types;
using GraphQLDemo.Entities;

namespace GraphQLDemo.GraphQL.GraphTypes
{
    public class StockType : ObjectGraphType<Stock>
    {
        public StockType()
        {
            Field(stock => stock.Id);
            Field(stock => stock.Name);
            Field(stock => stock.LastPrice);
        }
    }
}