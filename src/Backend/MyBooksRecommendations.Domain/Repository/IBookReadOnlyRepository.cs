using MyBooksRecommendations.Domain.Entity;
using MyBooksRecommendations.Domain.ValueObject;

namespace MyBooksRecommendations.Domain.Repository
{
    public interface IBookReadOnlyRepository
    {
        IList<Book> GetAllBooks(BookFilter? filter = null);
    }
}
