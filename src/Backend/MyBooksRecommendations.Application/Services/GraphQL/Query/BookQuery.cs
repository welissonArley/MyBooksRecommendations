using GraphQL;
using GraphQL.Types;
using MyBooksRecommendations.Application.Services.GraphQL.Type;
using MyBooksRecommendations.Application.UseCases.Book.Get;
using MyBooksRecommendations.Domain.Enuns;

namespace MyBooksRecommendations.Application.Services.GraphQL.Query
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(IGetBookUseCase useCase)
        {
            Field<ListGraphType<BookType>>(
                "books",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType>
                    {
                        Name = "author"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "language"
                    },
                    new QueryArgument<BookStatusType>
                    {
                        Name = "status"
                    },
                    new QueryArgument<BookCategoryType>
                    {
                        Name = "type"
                    }
                }),
                resolve: context =>
                {
                    var result = useCase.Execute(new Domain.ValueObject.BookFilter
                    {
                        Author = context.GetArgument<string?>("author") ?? "",
                        Language = context.GetArgument<string?>("language") ?? "",
                        Status = context.GetArgument<BookStatus?>("status"),
                        Type = context.GetArgument<Domain.Enuns.BookCategory?>("type")
                    });

                    return result;
                }
            );
        }
    }
}
