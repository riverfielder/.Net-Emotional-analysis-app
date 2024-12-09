namespace API
{
    // 文本分词接口，返回关键词
    public interface ISegmenter
    {
        public IEnumerable<string> SegmentText(string text);
    }
}
