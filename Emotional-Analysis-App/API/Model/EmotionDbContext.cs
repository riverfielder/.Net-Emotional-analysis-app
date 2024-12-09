using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace API
{
    public class EmotionDbContext : DbContext
    {
        public EmotionDbContext() : base("EmotionDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<EmotionRecord> EmotionRecords { get; set; }
        public DbSet<KeywordFrequency> KeywordFrequencies { get; set; }

    }
}
