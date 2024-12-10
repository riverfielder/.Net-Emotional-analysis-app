using API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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
        private ObservableCollection<string> _historyRecords = new ObservableCollection<string>();

        private string _inputText;

        private int _userId;

        private bool _isIncognitoMode = false;  // 默认关闭
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
                //if (_isRealTimeAnalysisEnabled)
                //{
                //    // 只有在实时分析开启时才进行情感分析
                //    AnalyzeAndSaveEmotion();
                //}
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

        public bool IsIncognitoMode
        {
            get => _isIncognitoMode;
            set
            {
                _isIncognitoMode = value;
            }
        }

        public ObservableCollection<string> HistoryRecords
        {
            get => _historyRecords;
            set
            {
                if (_historyRecords != value)
                {
                    _historyRecords = value;
                    OnPropertyChanged(nameof(HistoryRecords));
                }
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

        // 提交按钮点击事件
        public void SubmitAction()
        {
            if (string.IsNullOrEmpty(InputText))
            {
                // 如果没有输入文本，跳过
                return;
            }
            // 根据模式处理
            if (IsIncognitoMode == false)
            {
                AnalyzeAndSaveEmotion();
            }
            else
            {
                AnalyzeEmotion();
            }

            // 保存到历史记录中
            HistoryRecords.Add(InputText);  // 新记录插入到最前面
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

        public async void AnalyzeEmotion()
        {
            if (string.IsNullOrEmpty(InputText)) return;

            // 调用情感分析接口
            var sentimentResult = await _emotionService.GetSentimentAsync(InputText);

            if (sentimentResult != null)
            {
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
    // 历史记录类
    //public class HistoryRecord
    //{
    //    public string Text { get; set; }
    //}
}
