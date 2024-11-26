using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace UI
{
    public class DrawImage : IDrawImage
    {
        private int _width = 400;
        private int _height = 300;
        // 生成图云
        public BitmapSource GenerateWordCloud(Dictionary<string, int> wordFrequency)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(currentDirectory, "WordCloud.jpg");
            Image mask = Image.FromFile(imagePath);
            WordCloudGenerator wordCloudGenerator;
            if (mask == null)
            {
                wordCloudGenerator = new WordCloudGenerator(_width, _height);
            }
            else
            {
                wordCloudGenerator = new WordCloudGenerator(_width, _height, mask);
            }            
            return wordCloudGenerator.GenerateWordCloud(wordFrequency);
        }

        // 生成文本情感分析图像
        public BitmapSource GenerateEmotionImage(double positiveRatio)
        {
            EmotionImageGenerator emotionImageGenerator = new EmotionImageGenerator();
            return emotionImageGenerator.GenerateEmotionAnalysisChart(positiveRatio);
        }

        // 生成情感分析折线图
        public BitmapSource GenerateEmotionLineChartAsImage(Dictionary<int, double> emotionData)
        {
            EmotionImageGenerator emotionImageGenerator = new EmotionImageGenerator();
            return emotionImageGenerator.GenerateEmotionLineChartAsImage(emotionData);
        }
    }
}
