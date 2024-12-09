using API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace UI
{
    public class UserControl3ViewModel : INotifyPropertyChanged
    {
        private readonly EmotionAnalysisManager _emotionManager;
        private readonly IDrawImage _imageGenerator;

        private BitmapSource _emotionLineChartImage;
        public BitmapSource EmotionLineChartImage
        {
            get => _emotionLineChartImage;
            set
            {
                _emotionLineChartImage = value;
                OnPropertyChanged(nameof(EmotionLineChartImage));
            }
        }

        public UserControl3ViewModel(EmotionAnalysisManager emotionManager, IDrawImage imageGenerator)
        {
            _emotionManager = emotionManager;
            _imageGenerator = imageGenerator;
        }

        public void GenerateEmotionLineChart(int userId, int duration, string timeUnit)
        {
            var emotionData = _emotionManager.GetAverageSentiment(userId, duration, timeUnit);
            EmotionLineChartImage = _imageGenerator.GenerateEmotionLineChartAsImage(emotionData);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
