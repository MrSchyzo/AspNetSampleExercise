using NUnit.Framework;

namespace WordRetriever.Tests
{
    [TestFixture]
    public class LargestWordTests
    {
        private LargestWordRetriever retriever;

        [SetUp]
        public void SetUp()
        {
            retriever = new LargestWordRetriever();
        }

        /// <summary>
        /// In this challenge, empty string as argument has an undefined behavior: nothing is required in this case
        /// </summary>
        [Test]
        public void EmptyPhrase()
        {
            Assert.Pass("Empty phrase case hasn't any requirement: everything is ok");
        }

        /// <summary>
        /// In this challenge we had to make the assumption that the phrase isn't an empty string, but nothing has been
        /// said for strings that are only made of space or newline characters.
        /// In these cases, I chose to return null.
        /// By the way, this case is not specified, and that makes me think that this is another undefined behavior.
        /// </summary>
        [Test, TestCaseSource(typeof(WordRetrievalOnlySpaceCases))]
        public void SpaceOnlyCaseReturnsNull(string phrase)
        {
            //Given... (nothing more to be declared)

            //When...
            var largest = retriever.Retrieve(phrase);

            //Then...
            Assert.IsNull(largest, "Space-only string returns null value as longest word");
        }

        [Test]
        public void SingleWordPhraseReturnsThatWord()
        {
            //Given...
            var phrase = "Undefined";

            //When...
            var largest = retriever.Retrieve(phrase);

            //Then...
            Assert.AreEqual("Undefined", largest, "Single-word phrase returns that single word");
        }

        [Test]
        public void ReturnsTheLongestWord()
        {
            //Given...
            var phrase = "Return the largest word in this string";

            //When...
            var largest = retriever.Retrieve(phrase);

            //Then...
            Assert.AreEqual("largest", largest, "Must retrieve the largest word... literally!");
        }

        [Test]
        public void ReturnsTheFirstLongestWord()
        {
            //Given...
            var phrase = "Are you red or not";

            //When...
            var largest = retriever.Retrieve(phrase);

            //Then...
            Assert.AreEqual("Are", largest, "Must retrieve the first largest word");
        }
    }
}
