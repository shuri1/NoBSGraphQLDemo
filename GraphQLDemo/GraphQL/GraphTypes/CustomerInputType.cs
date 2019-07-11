using GraphQL.Types;

namespace GraphQLDemo.GraphQL.GraphTypes
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType(){
            
            Name = "CustomerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("address");
            Field<StringGraphType>("city");
            Field<StringGraphType>("state");
            Field<StringGraphType>("zipcode");
        }
    }
}