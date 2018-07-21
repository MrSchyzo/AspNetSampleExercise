using System.Collections;

namespace WordRetriever.Tests
{
    public class WordRetrievalOnlySpaceCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { "    " };
            yield return new object[] { "\n\n\n" };
            yield return new object[] { "\n \n  \n" };
        }
    }
}
