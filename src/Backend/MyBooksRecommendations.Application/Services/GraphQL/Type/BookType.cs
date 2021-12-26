using GraphQL.Types;
using MyBooksRecommendations.Communication.Response;

namespace MyBooksRecommendations.Application.Services.GraphQL.Type
{
    public class BookType : ObjectGraphType<ResponseBookJson>
    {
        public BookType()
        {
            Field(x => x.Title);
            Field(x => x.Author);
            Field(x => x.PrintLength);
            Field(x => x.Publication).Description("The version that I read was released in this date.");
            Field(x => x.Review).Description("Amazon review");
            Field(x => x.Language).Description("I read this book in this languages");
            Field(x => x.IReadAt).Description("The years that I read this book. If the value is greater than 1, that means that I read this book in this years");
            Field(x => x.Status).Description("Reading = 0 | Finished = 1");
            Field(x => x.Type).Description("Work = 0 | SoftSkills = 1 | Others = 2");
        }
    }
}
