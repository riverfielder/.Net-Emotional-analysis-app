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
    public class UserControl2ViewModel : INotifyPropertyChanged
    {
        private readonly EmotionAnalysisManager _emotionManager;
        private readonly IDrawImage _imageGenerator;

        private BitmapSource _wordCloudImage;
        public BitmapSource WordCloudImage
        {
            get => _wordCloudImage;
            set
            {
                _wordCloudImage = value;
                OnPropertyChanged(nameof(WordCloudImage));
            }
        }

        public UserControl2ViewModel(EmotionAnalysisManager emotionManager, IDrawImage imageGenerator)
        {
            _emotionManager = emotionManager;
            _imageGenerator = imageGenerator;
        }

        public void GenerateWordCloud(int userId)
        {
            var wordFrequencies = _emotionManager.GetTopKeywords(userId);
            WordCloudImage = _imageGenerator.GenerateWordCloud(wordFrequencies);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
