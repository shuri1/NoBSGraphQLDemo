using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL.Common.Request;
using GraphQLClient.Entities;

namespace GraphQLClient
{
    class Program
    {
        private const string  GraphQlServerUrl = "https://localhost:44326/graphQL";
        static async Task Main(string[] args)
        {
            //var customers = await SimpleWebClientDemo();
            var customers2 = await SimpleGraphQLClientDemo();

        }

        private static async Task<Customer> SimpleGraphQLClientDemo()
        {
            var customerRequest = new GraphQLRequest
            {
                Query = @"query Sample($customerId :Int, $portfolioId: Int)
                            {
                              customer:customer(id:$customerId)
                              {
                                id
                                address
                                 ...custFragment
                              }  
                            }
                            fragment custFragment on CustomerType
                            {
                              name
                              portfolio(id:$portfolioId)
                              {
                                name
                                id
                              }
                            }"
            };
//Query = @"{ 
//                               customers 
//                                 { 
//                                    id 
//                                    name 
//                                    portfolios 
//                                    { 
//                                        id 
//                                        stocks 
//                                        { 
//                                            id 
//                                            name 
//                                        } 
//                                    }  
//                                } 
//                            }"
//                        };

                //var temp = new {x = 1, y = 2};
            customerRequest.Variables = new {  portfolioId=  1, customerId = 2};
            
            var graphQLClient = new GraphQL.Client.GraphQLClient(GraphQlServerUrl);
            var graphQLResponse = await graphQLClient.PostAsync(customerRequest);
            var customer = graphQLResponse.GetDataFieldAs<Customer>("customer"); 
            var name = customer.Name;
            return customer;

        }

        private static async Task<List<Customer>> SimpleWebClientDemo()
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(GraphQlServerUrl)
            };

            var response = await client.GetAsync(@" ? query={ customers { id name portfolios { id stocks { id name } }  } }");
            var stringResult = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<RootObject>(stringResult);
            return root.Data.Customers;

        }
    }
}
