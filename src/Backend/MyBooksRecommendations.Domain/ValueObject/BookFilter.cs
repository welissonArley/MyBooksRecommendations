using MyBooksRecommendations.Domain.Enuns;

namespace MyBooksRecommendations.Domain.ValueObject
{
    public class BookFilter
    {
        public string Author { get; set; } = "";
        public string Language { get; set; } = "";
        public BookStatus? Status { get; set; }
        public BookCategory? Type { get; set; }
    }
}
