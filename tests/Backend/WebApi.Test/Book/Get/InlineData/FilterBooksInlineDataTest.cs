using MyBooksRecommendations.Domain.Enuns;
using System.Collections.Generic;

namespace WebApi.Test.Book.Get.InlineData
{
    public class FilterBooksInlineDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Dictionary<string, object> { { "author", "Martin Robert C." } } };
            yield return new object[] { new Dictionary<string, object> { { "language", "English" } } };
            yield return new object[] { new Dictionary<string, object> { { "status", BookStatus.Finished } } };
            yield return new object[] { new Dictionary<string, object> { { "type", BookCategory.Work } } };
            yield return new object[] { new Dictionary<string, object> { { "type", BookCategory.Work }, { "status", BookStatus.Reading } } };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
