using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class EmotionAnalysisManager
    {
        private readonly EmotionDbContext _dbContext;

        public EmotionAnalysisManager(EmotionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEmotionRecord(int userId, string text, SentimentResult sentimentResult)
        {
            var record = new EmotionRecord
            {
                UserId = userId,
                Text = text,
                Sentiment = sentimentResult.getSentiment(),
                Confidence = sentimentResult.getConfidence(),
                PositiveProbability = sentimentResult.getPostive_prob(),
                NegativeProbability = sentimentResult.getNegative_prob(),
                RecordedAt = DateTime.UtcNow
            };

            _dbContext.EmotionRecords.Add(record);
            _dbContext.SaveChanges();

            // 使用 Jieba 分词器更新高频词记录
            var segmenter = new Segmenter();
            var keywords = segmenter.SegmentText(text).ToList(); // 使用 Jieba 分词
            foreach (var keyword in keywords)
            {
                var keywordRecord = _dbContext.KeywordFrequencies.FirstOrDefault(k => k.UserId == userId && k.Keyword == keyword);
                if (keywordRecord != null)
                {
                    keywordRecord.Frequency++;
                }
                else
                {
                    _dbContext.KeywordFrequencies.Add(new KeywordFrequency
                    {
                        UserId = userId,
                        Keyword = keyword,
                        Frequency = 1
                    });
                }
            }
            _dbContext.SaveChanges();
        }

        public List<EmotionRecord> GetEmotionStatistics(int userId, DateTime startDate, DateTime endDate)
        {
            return _dbContext.EmotionRecords
                .Where(record => record.UserId == userId && record.RecordedAt >= startDate && record.RecordedAt <= endDate)
                .OrderByDescending(record => record.RecordedAt)
                .ToList();
        }
    }
}
