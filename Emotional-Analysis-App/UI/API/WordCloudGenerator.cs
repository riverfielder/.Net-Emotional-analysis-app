using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WordCloudSharp;

namespace UI
{
    public class WordCloudGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Image? _mask;

        public WordCloudGenerator(int width, int height, Image mask)
        {
            _width = width;
            _height = height;
            _mask = mask;
        }
        public WordCloudGenerator(int width, int height)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// 根据输入的单词及其频率生成词云，并返回 WPF 可用的 BitmapSource。
        /// </summary>
        /// <param name="wordFrequency">单词及其频率的字典</param>
        /// <returns>生成的词云图像作为 BitmapSource</returns>
        public BitmapSource GenerateWordCloud(Dictionary<string, int> wordFrequency)
        {
            if (wordFrequency == null || wordFrequency.Count == 0)
                return null;

            // 提取单词和频率列表
            var words = wordFrequency.Select(it => it.Key).ToList();
            var frequencies = wordFrequency.Select(it => it.Value).ToList();

            // 使用 WordCloudSharp 生成词云
            WordCloud wordCloud;
            if (_mask == null)
                wordCloud = new WordCloud(_width, _height);
            else
                wordCloud = new WordCloud(_width, _height, mask: _mask, allowVerical: true);
            var image = wordCloud.Draw(words, frequencies);

            // 将生成的 Image 转换为 Bitmap 并再转为 WPF BitmapSource
            var bitmap = new Bitmap(image);
            var hBitmap = bitmap.GetHbitmap();

            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
        }
    }
}

