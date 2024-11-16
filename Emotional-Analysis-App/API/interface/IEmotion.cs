using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    // 文本情感分析接口，
    public interface IEmotion
    {
        // text默认按GBK进行编码，返回对text的情感分析结果
        Task<SentimentResult> GetSentimentAsync(string text);
    }
}
