using MyBooksRecommendations.Domain.Entity;
using MyBooksRecommendations.Domain.Enuns;
using MyBooksRecommendations.Domain.Repository;
using MyBooksRecommendations.Domain.ValueObject;

namespace MyBooksRecommendations.Infrastructure.DataAccess.Repositories
{
    public class BookRepository : IBookReadOnlyRepository
    {
        public IList<Book> GetAllBooks(BookFilter? filter = null)
        {
            var books = BooksOnDatabase();

            if(filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Author))
                    books = books.Where(c => c.Author.Equals(filter.Author)).ToList();

                if (!string.IsNullOrEmpty(filter.Language))
                    books = books.Where(c => c.Language.Contains(filter.Language)).ToList();

                if (filter.Status.HasValue)
                    books = books.Where(c => c.Status == filter.Status.Value).ToList();

                if (filter.Type.HasValue)
                    books = books.Where(c => c.Type == filter.Type.Value).ToList();
            }
            
            return books;
        }

        private IList<Book> BooksOnDatabase()
        {
            var workBooks = WorkBooks();
            var softSkillBooks = SoftSkillBooks();
            var otherCategoriesBooks = OtherCategoriesBooks();

            var list = new List<Book>(workBooks.Count + softSkillBooks.Count + otherCategoriesBooks.Count);

            list.AddRange(workBooks);
            list.AddRange(softSkillBooks);
            list.AddRange(otherCategoriesBooks);

            return list;
        }

        private IList<Book> WorkBooks()
        {
            return new List<Book>
            {
                new Book {Title = "How Smart Machines Think", Status = BookStatus.Reading, Author = "Kevin Scott", Type = BookCategory.Work, Language = new List<string> { "English" }, PrintLength = 312, Publication = new DateTime(2019, 10, 22), Review = "Everything you've always wanted to know about self-driving cars, Netflix recommendations, IBM's Watson, and video game-playing computer programs."},
                new Book {Title = "Scrum: The Art of Doing Twice the Work in Half the Time", Status = BookStatus.Finished, Type = BookCategory.Work, IReadAt = new List<uint> { 2021 }, Author = "J.J. Sutherland", Language = new List<string> { "English" }, PrintLength = 256, Publication = new DateTime(2014, 09, 30), Review = "For those who believe that there must be a more agile and efficient way for people to get things done, here is a brilliantly discursive, thought-provoking book about the leadership and management process that is changing the way we live."},
                new Book {Title = "Refactoring: Improving the Design of Existing Code", Author = "Martin Fowler", Status = BookStatus.Finished, Type = BookCategory.Work, Language = new List<string> { "Portuguese" }, IReadAt = new List<uint> { 2020 }, PrintLength = 432, Publication = new DateTime(2018, 11, 20), Review = "Any fool can write code that a computer can understand. Good programmers write code that humans can understand."},
                new Book {Title = "14 Habits of Highly Productive Developers", Author = "Zeno Rocha", Status = BookStatus.Finished, Type = BookCategory.Work, Language = new List<string> { "Portuguese" }, IReadAt = new List<uint> { 2020 }, PrintLength = 158, Publication = new DateTime(2020, 07, 14), Review = "You can learn the most popular frameworks, use the best programming languages, and work at the biggest tech companies, but if you cultivate bad habits, it will be hard for you to become a top developer."},
                new Book {Title = "Clean Architecture: A Craftsman's Guide to Software Structure and Design", Author = "Martin Robert C.", Type = BookCategory.Work, Status = BookStatus.Finished, Language = new List<string> { "Portuguese" }, IReadAt = new List<uint> { 2020 }, PrintLength = 430, Publication = new DateTime(2017, 09, 12), Review = "By applying universal rules of software architecture, you can dramatically improve developer productivity throughout the life of any software system."},
                new Book {Title = "How to Be a Graphic Designer without Losing Your Soul", Author = "Adrian Shaughnessy", Type = BookCategory.Work, Status = BookStatus.Finished, Language = new List<string> { "English" }, PrintLength = 176, IReadAt = new List<uint> { 2021 }, Publication = new DateTime(2010, 09, 22), Review = "Brings the essential text up to date with new chapters on professional skills, the creative process, and global trends that include social responsibility, ethics, and the rise of digital culture"},
            };
        }
        private IList<Book> SoftSkillBooks()
        {
            return new List<Book>
            {
                new Book {Title = "Outwitting the Devil: The Secret to Freedom and Success", Author = "Napoleon Hill", Status = BookStatus.Finished, Type = BookCategory.SoftSkills, Language = new List<string> { "Portugues" }, IReadAt = new List<uint> { 2020 }, PrintLength = 288, Publication = new DateTime(2020, 03, 19), Review = "Using his legendary ability to get to the root of human potential, Napoleon Hill digs deep to reveal how fear, procrastination, anger, and jealousy prevent us from realizing our personal goals."},
                new Book {Title = "Rich Dad Poor Dad", Author = "Robert T. Kiyosaki", Type = BookCategory.SoftSkills, Status = BookStatus.Finished, Language = new List<string> { "Portuguese", "French" }, PrintLength = 336, IReadAt = new List<uint> { 2021, 2021 }, Publication = new DateTime(2017, 04, 11), Review = "What the Rich Teach Their Kids About Money That the Poor and Middle Class Do Not!"},
                new Book {Title = "Coach Wooden's Pyramid of Success", Author = "Jay Carty", Type = BookCategory.SoftSkills, Status = BookStatus.Reading, Language = new List<string> { "Portuguese" }, PrintLength = 195, IReadAt = new List<uint> { }, Publication = new DateTime(2009, 08, 14), Review = "Legendary college basketball coach John Wooden and Jay Carty know that when it comes down to it, success is an equal opportunity player."},
                new Book {Title = "Why Generalists Triumph in a Specialized World", Author = "David J. Epstein", Type = BookCategory.SoftSkills, Status = BookStatus.Finished, Language = new List<string> { "Portuguese" }, PrintLength = 351, IReadAt = new List<uint> { 2020 }, Publication = new DateTime(2019, 05, 28), Review = "David Epstein examined the world’s most successful athletes, artists, musicians, inventors, forecasters and scientists. He discovered that in most fields—especially those that are complex and unpredictable—generalists, not specialists, are primed to excel. Generalists often find their path late, and they juggle many interests rather than focusing on one. They’re also more creative, more agile, and able to make connections their more specialized peers can’t see."},
            };
        }
        private IList<Book> OtherCategoriesBooks()
        {
            return new List<Book>
            {
                new Book {Title = "Origin: A Novel", Author = "Dan Brown", Type = BookCategory.Others, Status = BookStatus.Finished, Language = new List<string> { "Portuguese" }, PrintLength = 463, IReadAt = new List<uint> { 2021 }, Publication = new DateTime(2017, 10, 03), Review = "Robert Langdon, Harvard professor of symbology, arrives at the ultramodern Guggenheim Museum Bilbao to attend the unveiling of a discovery that “will change the face of science forever.” The evening’s host is Edmond Kirsch, a forty-year-old billionaire and futurist, and one of Langdon’s first students."},
                new Book {Title = "Deception Point", Author = "Dan Brown", Type = BookCategory.Others, Status = BookStatus.Finished, Language = new List<string> { "Portuguese" }, PrintLength = 464, IReadAt = new List<uint> { 2021 }, Publication = new DateTime(2002, 12, 02), Review = "A shocking scientific discovery. A conspiracy of staggering brilliance. A thriller unlike any you've ever read."}
            };
        }
    }
}
