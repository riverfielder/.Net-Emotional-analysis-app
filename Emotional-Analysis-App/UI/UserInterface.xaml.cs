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
        UserControl userControl1;
        UserControl userControl2;
        UserControl userControl3;

        private UserControl1ViewModel _userControl1ViewModel;
        private UserControl2ViewModel _userControl2ViewModel;
        private UserControl3ViewModel _userControl3ViewModel;

        public string userName;
        private int userId; // 用于存储从 username（Tag）中解析出的 userId


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
            t1.Text = userId.ToString();

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
        }

        private int GetUserIdByUsername(string username, EmotionDbContext emotionDb)
        {
            var userRepository = new UserRepository(emotionDb);
            var id = userRepository.GetUserIdByUsername(username);
            System.Windows.MessageBox.Show("get userId:" + id);
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

        private void SearchFeeling(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        {

        }



        private void home_Click(object sender, RoutedEventArgs e)
        {
            cont.Content = userControl1;
            System.Windows.MessageBox.Show("get userId:" + userId);
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
    }
}
