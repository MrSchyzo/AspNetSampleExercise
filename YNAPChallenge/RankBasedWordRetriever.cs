using System;
using System.Collections.Generic;
using System.Linq;

namespace WordRetriever
{
    public abstract class RankBasedWordRetriever : IWordRetriever
    {
        abstract protected IEnumerable<string> RankWords(IEnumerable<string> words);

        public string Retrieve(string phrase)
        {
            var words = phrase.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return RankWords(words).FirstOrDefault();
        }
    }
}
