namespace WordRetriever
{
    public class LargestWordRetriever : BestWordRetriever<int>
    {
        public LargestWordRetriever() : base(word => word.Length) { }
    }
}
