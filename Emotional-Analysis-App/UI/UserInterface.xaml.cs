using API;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WordCloudSharp;

namespace UI
{
    /// <summary>
    /// UserInterface.xaml 的交互逻辑
    /// </summary>
    public partial class UserInterface : System.Windows.Window
    {
        UserControl1 userControl1;
        UserControl userControl2;
        UserControl userControl3;

        private UserControl1ViewModel _userControl1ViewModel;
        private UserControl2ViewModel _userControl2ViewModel;
        private UserControl3ViewModel _userControl3ViewModel;

        public string userName;
        private int userId; // 用于存储从 username（Tag）中解析出的 userId

        //private bool _isIncognitoMode = false;


        public UserInterface(string username)
        {
            InitializeComponent();
            userName = username;
            //将数据源显示到AxleCanvas
            userControl1 = new UserControl1();
            userControl2 = new UserControl2();
            userControl3 = new UserControl3();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            username.Content = userName;
            // 从 Tag 中获取 username 并解析 userId
            //初始化时通过tag选择对应用户的数据源
            string user = userName;
            

            // 初始化 ViewModels
            var dbContext = new EmotionDbContext();
            var emotionManager = new EmotionAnalysisManager(dbContext);
            var emotionService = new Emotion();
            var imageGenerator = new DrawImage();

            userId = GetUserIdByUsername(user, dbContext);
         

            _userControl1ViewModel = new UserControl1ViewModel(emotionManager, emotionService, imageGenerator);
            _userControl2ViewModel = new UserControl2ViewModel(emotionManager, imageGenerator);
            _userControl3ViewModel = new UserControl3ViewModel(emotionManager, imageGenerator);

            _userControl1ViewModel.SetUserId(userId);

            // 绑定数据上下文
            userControl1.DataContext = _userControl1ViewModel;
            userControl2.DataContext = _userControl2ViewModel;
            userControl3.DataContext = _userControl3ViewModel;

            // 初始化默认页面
            cont.Content = userControl1;

            // 启动剪贴板监听
            ClipboardNotification.Start();
        }

        private int GetUserIdByUsername(string username, EmotionDbContext emotionDb)
        {
            var userRepository = new UserRepository(emotionDb);
            var id = userRepository.GetUserIdByUsername(username);
            return id;
        }

        private void UserChanged(object sender, EventArgs e)
        {
            System.Windows.Window userInterface = Application.Current.Windows.OfType<UserInterface>().FirstOrDefault();
            if (userInterface != null)
            {
                Login login = new Login();
                login.Show();
                userInterface.Close();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cont.Content == userControl3)
            {
                var selectedItem = (sender as System.Windows.Controls.ComboBox)?.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    int duration;
                    string timeUnit;

                    if (selectedItem.Content.ToString().Contains("minute"))
                    {
                        duration = 30;
                        timeUnit = "minute";
                    }
                    else if (selectedItem.Content.ToString().Contains("hour"))
                    {
                        duration = 24;
                        timeUnit = "hour";
                    }
                    else
                    {
                        duration = 7;
                        timeUnit = "day";
                    }

                    // 更新折线图
                    _userControl3ViewModel.GenerateEmotionLineChart(userId, duration, timeUnit);
                }
            }

        }

       


        private void home_Click(object sender, RoutedEventArgs e)
        {
            cont.Content = userControl1;

            // 如果需要，加载与用户相关的情感分析结果
            //_userControl1ViewModel.InputText = string.Empty; // 清空默认输入框
            //_userControl1ViewModel.EmotionImage = null;      // 清空默认图片
        }

        private void wordcloud_Click(object sender, RoutedEventArgs e)
        {
            cont.Content = userControl2;
            // 生成用户词云
            _userControl2ViewModel.GenerateWordCloud(userId);

        }


        private void graphs_Click(object sender, RoutedEventArgs e)
        {
            cont.Content = userControl3;
            // 动态生成情感变化折线图，默认前 24 小时
            _userControl3ViewModel.GenerateEmotionLineChart(userId, 24, "hour");

        }

        private async void settings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //选项一：切换数据来源为粘贴板
            //选项二：实现无痕浏览 即不保存用户数据到数据库
            var selectedSetting = settings.SelectedItem as ComboBoxItem;
            if (selectedSetting != null)
            {
                if (selectedSetting.Content.ToString() == "Incognito mode")
                {
                    _userControl1ViewModel.IsIncognitoMode = true;
                }
                else
                {
                    _userControl1ViewModel.IsIncognitoMode = false;
                }
                if (selectedSetting.Content.ToString() == "Pasteboard")
                {
                    // 订阅剪贴板更新事件
                    ClipboardNotification.ClipboardUpdated += OnClipboardUpdated;
                }
                else
                {
                    ClipboardNotification.ClipboardUpdated -= OnClipboardUpdated;
                }
                if (selectedSetting.Content.ToString() == "Clear data")
                {
                    var dbContext = new EmotionDbContext();
                    var emotionManager = new EmotionAnalysisManager(dbContext);
                    emotionManager.ClearEmotionRecordsAsync(userId);
                    emotionManager.ClearKeywordFrequenciesAsync(userId);
                    _userControl1ViewModel.InputText = string.Empty; // 清空输入框
                    _userControl1ViewModel.EmotionImage = null;      // 清空图片
                    _userControl1ViewModel.HistoryRecords.Clear();
                }
            }
        }

        // 剪贴板更新事件处理
        private void OnClipboardUpdated(object sender, EventArgs e)
        {
            // 在UI线程更新UI控件
            Dispatcher.Invoke(() =>
            {
                // 你可以在这里获取剪贴板的内容，更新UI
                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();
                    userControl1.homeText.Text = clipboardText;
                    _userControl1ViewModel.SubmitAction();
                }
            });
        }

        // 确保窗口关闭时取消监听
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // 如果需要，取消事件订阅
            ClipboardNotification.ClipboardUpdated -= OnClipboardUpdated;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //保存对应词云或者折线图的数据到本地
            // 检查当前界面是哪一个
            if (cont.Content is UserControl2 userControl2)
            {
                var image = userControl2.wordcloudImage; // 获取当前显示的图像
                if (image != null)
                {
                    var drawImageService = new DrawImage();  
                    drawImageService.SaveImg((BitmapSource)image.Source);
                }
            }
            else if (cont.Content is UserControl3 userControl3)
            {
                var image = userControl3.graphsImage; // 获取当前显示的图像
                if (image != null)
                {
                    var drawImageService = new DrawImage(); 
                    drawImageService.SaveImg((BitmapSource)image.Source);
                }
            }
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            _userControl1ViewModel.SubmitAction();
        }
    }
}
