using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public interface IEmotion
    {
        // 文本情感分析接口，text默认按GBK进行编码
        Task<SentimentResult> GetSentimentAsync(string text);
    }
}
