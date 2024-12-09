using Microsoft.Win32;
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
            string BaseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "API"));
            string imgFileName = "WordCloud.jpg";
            string imagePath = Path.GetFullPath(Path.Combine(BaseDirectory, imgFileName));
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

        // 将图像保存在本地，失败返回false
        public bool SaveImg(BitmapSource bitmapSource)
        {
            // 创建一个保存文件对话框
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 设置文件类型（可根据需要设置不同的扩展名）
            saveFileDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|All files (*.*)|*.*";

            // 显示对话框并判断用户是否选择了文件
            if (saveFileDialog.ShowDialog() == true)
            {
                // 获取用户选择的路径
                string filePath = saveFileDialog.FileName;

                // 判断文件扩展名并选择合适的编码器
                BitmapEncoder encoder = null;
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".png")
                {
                    encoder = new PngBitmapEncoder();
                }
                else if (extension == ".jpg" || extension == ".jpeg")
                {
                    encoder = new JpegBitmapEncoder();
                }
                else
                {
                    return false;
                }

                // 将 BitmapSource 转换为文件格式
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                // 使用 FileStream 保存文件
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    encoder.Save(fileStream);
                }

                return true;
            }
            return false;
        }

    }
}
