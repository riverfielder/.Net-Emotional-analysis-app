
using JiebaNet.Segmenter;

namespace API
{
    public class Segmenter : ISegmenter
    {
        private JiebaSegmenter segmenter;

        public Segmenter()
        {
            segmenter = new JiebaSegmenter();
        }
        public IEnumerable<string> SegmentText(string text)
        {
            return segmenter.Cut(text, cutAll: false);
        }
    }
}
