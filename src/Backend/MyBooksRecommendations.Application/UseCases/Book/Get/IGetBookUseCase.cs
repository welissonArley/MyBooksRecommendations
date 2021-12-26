using MyBooksRecommendations.Communication.Response;
using MyBooksRecommendations.Domain.ValueObject;

namespace MyBooksRecommendations.Application.UseCases.Book.Get
{
    public interface IGetBookUseCase
    {
        IList<ResponseBookJson> Execute(BookFilter? filter = null);
    }
}
