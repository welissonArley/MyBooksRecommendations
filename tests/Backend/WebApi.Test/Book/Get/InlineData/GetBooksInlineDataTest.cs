using System.Collections.Generic;

namespace WebApi.Test.Book.Get.InlineData
{
    public class GetBooksInlineDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new string[] { "title" } };
            yield return new object[] { new string[] { "author", "status" } };
            yield return new object[] { new string[] { "type", "language", "review", "iReadAt" } };
            yield return new object[] { new string[] { "printLength", "publication" } };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
