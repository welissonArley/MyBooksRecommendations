using MyBooksRecommendations.Domain.Enuns;

namespace MyBooksRecommendations.Domain.Entity
{
    public class Book
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public uint PrintLength { get; set; }
        public DateTime Publication { get; set; }
        public string Review { get; set; } = "";
        public IList<string> Language { get; set; } = new List<string>();
        public IList<uint> IReadAt { get; set; } = new List<uint>();
        public BookStatus Status { get; set; }
        public BookCategory Type { get; set; }
    }
}
