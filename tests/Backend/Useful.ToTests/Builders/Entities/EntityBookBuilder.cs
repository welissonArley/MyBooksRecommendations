using Bogus;
using MyBooksRecommendations.Domain.Entity;
using MyBooksRecommendations.Domain.Enuns;

namespace Useful.ToTests.Builders.Entities
{
    public class EntityBookBuilder
    {
        private static EntityBookBuilder _instance;

        public static EntityBookBuilder Instance()
        {
            _instance = new EntityBookBuilder();
            return _instance;
        }

        public Book Build()
        {
            return new Faker<Book>()
                .RuleFor(u => u.Title, (f) => f.Internet.UserName())
                .RuleFor(u => u.Author, (f, u) => f.Person.FirstName)
                .RuleFor(u => u.PrintLength, (f) => f.Random.UInt(min: 100, max: 800))
                .RuleFor(u => u.Publication, (f) => f.Date.Past(yearsToGoBack: f.Random.Int(min: 1, max: 20)))
                .RuleFor(u => u.Review, (f) => f.Lorem.Paragraph())
                .RuleFor(u => u.Language, (f) => new List<string>
                {
                    f.PickRandomParam<string>(new string[] { "Portuguese", "English", "French" })
                })
                .RuleFor(u => u.IReadAt, (f, u) => new List<uint>
                {
                    (uint)DateTime.Today.Year
                })
                .RuleFor(u => u.Status, (f) => f.PickRandom<BookStatus>())
                .RuleFor(u => u.Type, (f) => f.PickRandom<BookCategory>());
        }
    }
}
