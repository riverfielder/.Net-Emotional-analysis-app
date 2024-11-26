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
        public Dictionary<string, int> GetTopKeywords(int userId)
        {
            // 查询前 30 的关键词按频率降序排列
            var topKeywords = _dbContext.KeywordFrequencies
                .Where(k => k.UserId == userId)
                .OrderByDescending(k => k.Frequency)
                .Take(30)
                .Select(k => new { k.Keyword, k.Frequency })
                .ToList();
            // 转换为字典

            return topKeywords.ToDictionary(k => k.Keyword, k => k.Frequency);
        }

        /// <summary>
        /// 查询从当前时间起前 x 分钟/小时/天的情感记录，并计算每个时间段的情感平均值。
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="duration">时间范围，例如查询前 x 分钟/小时/天</param>
        /// <param name="timeUnit">时间单位，可选值为 "minute", "hour", "day"</param>
        /// <returns>返回一个字典，其中 Key 是时间段，Value 是该时间段的情感平均值</returns>
        public Dictionary<int, double> GetAverageSentiment(int userId, int duration, string timeUnit)
        {
            DateTime now = DateTime.UtcNow;

            // 确定时间间隔
            TimeSpan interval = timeUnit.ToLower() switch
            {
                "minute" => TimeSpan.FromMinutes(1),
                "hour" => TimeSpan.FromHours(1),
                "day" => TimeSpan.FromDays(1),
                _ => throw new ArgumentException("Invalid time unit. Use 'minute', 'hour', or 'day'.")
            };

            // 计算开始时间
            DateTime startTime = now - duration * interval;

            // 查询时间范围内的记录
            var records = _dbContext.EmotionRecords
                .Where(r => r.UserId == userId && r.RecordedAt >= startTime && r.RecordedAt <= now)
                .ToList();

            // 按时间段分组统计情感平均值
            var groupedSentiments = records
                .GroupBy(record =>
                {
                    int timeDifference = (int)((now - record.RecordedAt).TotalMinutes / interval.TotalMinutes);
                    return duration - timeDifference; // 转换为从当前倒数第几段
                })
                .Where(g => g.Key > 0) // 排除超出范围的时间段
                .ToDictionary(
                    g => g.Key, // Key: 时间段
                    g => g.Average(record => record.Sentiment) // Value: 平均情感值
                );

            // 填补空缺时间段为 0
            var result = new Dictionary<int, double>();
            for (int i = 1; i <= duration; i++)
            {
                result[i] = groupedSentiments.ContainsKey(i) ? groupedSentiments[i] : 0.0;
            }

            return result;
        }
    }
}
