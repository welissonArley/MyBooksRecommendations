using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using MyBooksRecommendations.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Test
{
    public class BaseControllersTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly IGraphQLClient _httpClient;

        public BaseControllersTest(CustomWebApplicationFactory<Program> factory)
        {
            var httpClient = factory.CreateClient();
            _httpClient = new GraphQLHttpClient(new GraphQLHttpClientOptions { EndPoint = new Uri("https://localhost:7048/graphql") }, new SystemTextJsonSerializer(), httpClient);
        }

        protected async Task<GraphQLResponse<object>> DoGraphQLRequest(GraphQLRequest query)
        {
            return await _httpClient.SendQueryAsync<object>(query);
        }
        protected GraphQLRequest CreateQuery(string queryName, string[] fields, Dictionary<string, object>? filter = null)
        {
            return new GraphQLRequest
            {
                Query = $@"{{ {queryName} {(Filter(filter))} {{ { string.Join(',', fields) } }} }}"
            };
        }
        private string Filter(Dictionary<string, object>? filter)
        {
            var result = "(";
            if (filter != null && filter.Any())
            {
                foreach(var value in filter)
                    result = $"{result}{value.Key}: {ParseValue(value.Value)},";

                return $"{result.Remove(result.Length - 1)})";
            }

            return "";
        }

        private string ParseValue(object value)
        {
            if (value is string)
                return $@"""{value}""";

            return $"{value}";
        }
    }
}