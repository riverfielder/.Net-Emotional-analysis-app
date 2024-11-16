

namespace API
{
    // 对文本进行情感分析的结果
    public class SentimentResult
    {
        // 表示情感极性分类结果，0:负向，1:中性，2:正向
        int sentiment;
        // 表示分类的置信度，取值范围[0,1]
        double confidence;
        // 表示属于积极类别的概率 ，取值范围[0, 1]
        double positive_prob;
        // 	表示属于消极类别的概率，取值范围[0,1]
        double negative_prob;

        public SentimentResult(int sentiment, double confidence, double positive_prob, double negative_prob)
        {
            this.sentiment = sentiment;
            this.confidence = confidence;
            this.positive_prob = positive_prob;
            this.negative_prob = negative_prob;
        }
        public int getSentiment() { return sentiment; }
        public double getConfidence() { return confidence; }
        public double getPostive_prob() { return positive_prob; }
        public double getNegative_prob() {return negative_prob; }
    }
}
