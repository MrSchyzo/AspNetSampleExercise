using System;
using System.Collections.Generic;
using System.Linq;

namespace WordRetriever
{
    public class BestWordRetriever<T> : RankBasedWordRetriever
        where T : IComparable<T>
    {
        private Func<string, T> ranking;

        public BestWordRetriever(Func<string, T> ranking)
            => this.ranking = ranking;

        protected override IEnumerable<string> RankWords(IEnumerable<string> words)
            => words.OrderByDescending(ranking);
    }
}
