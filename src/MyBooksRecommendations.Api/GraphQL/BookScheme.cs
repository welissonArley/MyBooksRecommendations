using GraphQL.Types;
using MyBooksRecommendations.Application.Services.GraphQL.Query;

namespace MyBooksRecommendations.Api.GraphQL
{
    public class BookScheme : Schema
    {
        public BookScheme(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<BookQuery>();
        }
    }
}
