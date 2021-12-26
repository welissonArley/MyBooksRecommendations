using FluentAssertions;
using GraphQL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Test.Book.Get.InlineData;
using Xunit;

namespace WebApi.Test.Book.Get
{
    public class Get : BaseControllersTest
    {
        public Get(CustomWebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        [ClassData(typeof(GetBooksInlineDataTest))]
        public async Task Validade_Sucess(string[] fields)
        {
            var query = CreateQuery(queryName: "books", fields: fields);

            var response = await DoGraphQLRequest(query);

            response.Errors.Should().BeNullOrEmpty();

            var responseData = JsonConvert.DeserializeObject<JObject>(response.Data.ToString());
            responseData.HasValues.Should().BeTrue();

            var books = responseData.GetValue("books");

            foreach(var book in books.AsJEnumerable())
            {
                var value = book.As<JObject>();
                value.Count.Should().Be(fields.Length);

                ValidateResult(value, "title", fields.Contains("title"));
                ValidateResult(value, "author", fields.Contains("author"));
                ValidateResult(value, "printLength", fields.Contains("printLength"));
                ValidateResult(value, "publication", fields.Contains("publication"));
                ValidateResult(value, "review", fields.Contains("review"));
                ValidateResult(value, "language", fields.Contains("language"));
                ValidateResult(value, "iReadAt", fields.Contains("iReadAt"));
                ValidateResult(value, "status", fields.Contains("status"));
                ValidateResult(value, "type", fields.Contains("type"));
            }
        }

        [Theory]
        [ClassData(typeof(FilterBooksInlineDataTest))]
        public async Task Validade_Sucess_WithParameters(Dictionary<string, object> filter)
        {
            var fields = new string[] { "title" };

            var query = CreateQuery(queryName: "books", fields: fields, filter: filter);

            var response = await DoGraphQLRequest(query);

            response.Errors.Should().BeNullOrEmpty();

            var responseData = JsonConvert.DeserializeObject<JObject>(response.Data.ToString());
            responseData.HasValues.Should().BeTrue();

            var books = responseData.GetValue("books");

            foreach (var book in books.AsJEnumerable())
            {
                var value = book.As<JObject>();
                value.Count.Should().Be(fields.Length);

                ValidateResult(value, "title", fields.Contains("title"));
                ValidateResult(value, "author", fields.Contains("author"));
                ValidateResult(value, "printLength", fields.Contains("printLength"));
                ValidateResult(value, "publication", fields.Contains("publication"));
                ValidateResult(value, "review", fields.Contains("review"));
                ValidateResult(value, "language", fields.Contains("language"));
                ValidateResult(value, "iReadAt", fields.Contains("iReadAt"));
                ValidateResult(value, "status", fields.Contains("status"));
                ValidateResult(value, "type", fields.Contains("type"));
            }
        }

        private void ValidateResult(JObject value, string filedName, bool shouldBeNOTNull)
        {
            var filedValue = value.GetValue(filedName);
            if (shouldBeNOTNull)
                filedValue.Should().NotBeNull();
            else
                filedValue.Should().BeNullOrEmpty();
        }
    }
}
