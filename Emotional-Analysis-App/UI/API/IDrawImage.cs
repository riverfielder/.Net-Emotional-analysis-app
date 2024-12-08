using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace UI
{
    public interface IDrawImage
    {
        // 生成词云
        public BitmapSource GenerateWordCloud(Dictionary<string, int> wordFrequency);

        // 生成文本情感分析图
        public BitmapSource GenerateEmotionImage(double positiveRatio);

        // 生成情感变化折线图
        public BitmapSource GenerateEmotionLineChartAsImage(Dictionary<int, double> emotionData);

        // 将图像保存在本地，失败返回false
        public bool SaveImg(BitmapSource bitmapSource);
    }
}
