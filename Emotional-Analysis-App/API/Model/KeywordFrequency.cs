using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class KeywordFrequency
    {
        [Key]
        public int KeywordId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string Keyword { get; set; }
        public int Frequency { get; set; }
    }
}
