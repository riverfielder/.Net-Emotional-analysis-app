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
    public class UserControl1ViewModel : INotifyPropertyChanged
    {
        private readonly EmotionAnalysisManager _emotionManager;
        private readonly IEmotion _emotionService;
        private readonly IDrawImage _imageGenerator;

        private string _inputText;

        private int _userId;
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
                AnalyzeAndSaveEmotion();
            }
        }

        private BitmapSource _emotionImage;
        public BitmapSource EmotionImage
        {
            get => _emotionImage;
            set
            {
                _emotionImage = value;
                OnPropertyChanged(nameof(EmotionImage));
            }
        }

        public UserControl1ViewModel(
            EmotionAnalysisManager emotionManager,
            IEmotion emotionService,
            IDrawImage imageGenerator)
        {
            _emotionManager = emotionManager;
            _emotionService = emotionService;
            _imageGenerator = imageGenerator;
        }

        public async void AnalyzeAndSaveEmotion()
        {
            if (string.IsNullOrEmpty(InputText)) return;

            // 调用情感分析接口
            var sentimentResult = await _emotionService.GetSentimentAsync(InputText);

            if (sentimentResult != null)
            {
                // 保存分析结果到数据库
                _emotionManager.AddEmotionRecord(_userId, InputText, sentimentResult);

                // 生成情感分析图片
                EmotionImage = _imageGenerator.GenerateEmotionImage(sentimentResult.getPostive_prob());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetUserId(int userId)
        {
            _userId = userId; 
        }
    }
}
