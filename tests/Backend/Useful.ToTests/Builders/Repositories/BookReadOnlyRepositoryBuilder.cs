using Moq;
using MyBooksRecommendations.Domain.Entity;
using MyBooksRecommendations.Domain.Repository;
using MyBooksRecommendations.Domain.ValueObject;

namespace Useful.ToTests.Builders.Repositories
{
    public class BookReadOnlyRepositoryBuilder
    {
        private static BookReadOnlyRepositoryBuilder _instance;
        private readonly Mock<IBookReadOnlyRepository> _repository;

        private BookReadOnlyRepositoryBuilder()
        {
            if (_repository == null)
                _repository = new Mock<IBookReadOnlyRepository>();
        }

        public static BookReadOnlyRepositoryBuilder Instance()
        {
            _instance = new BookReadOnlyRepositoryBuilder();
            return _instance;
        }

        public BookReadOnlyRepositoryBuilder GetAllBooks(List<Book> bookList)
        {
            _repository.Setup(x => x.GetAllBooks(It.IsAny<BookFilter>())).Returns(bookList);
            return this;
        }

        public IBookReadOnlyRepository Build()
        {
            return _repository.Object;
        }
    }
}
