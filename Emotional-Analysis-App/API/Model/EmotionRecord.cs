using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class EmotionRecord
    {
        [Key]
        public int RecordId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Text { get; set; }
        public int Sentiment { get; set; } // 0: 负向, 1: 中性, 2: 正向
        public double Confidence { get; set; }
        public double PositiveProbability { get; set; }
        public double NegativeProbability { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
    }
}
