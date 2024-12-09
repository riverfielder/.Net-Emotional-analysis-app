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
using API;
using HandyControl.Controls;
using MahApps.Metro.Controls;
using MessageBox = System.Windows.MessageBox;
using Window = System.Windows.Window;
namespace UI
{
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window loginWindow = Application.Current.Windows.OfType<Login>().FirstOrDefault();
            if (loginWindow != null)
            {
                loginWindow.IsEnabled = true;
                ToggleSwitch toggleSwitch = loginWindow.FindName("registSwitch") as ToggleSwitch;
                if (toggleSwitch != null)
                {
                    toggleSwitch.IsOn = false;
                }
            }
        }

        private async void UserRegistAsync(object sender, RoutedEventArgs e)
        {
            //注册用户
            //注册成功后关闭窗口
            //并将用户数据写入数据库
            //注册失败则提示用户注册失败
            string username = usernameBox.Text;
            string password = passwordBox.Text;//如果两次密码输入一致，用passwordagain的值
            string repeatpassword = repeatpasswordBox.Password;
            using (var _dbContext = new EmotionDbContext())
            {
                IUserRepository userRepository = new UserRepository(_dbContext);
                if (password != repeatpassword)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var success = await userRepository.RegisterUserAsync(username, password, repeatpassword);
                if (success)
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Optionally close the registration window or navigate to login
                    registerWindow.Close();
                }
                else
                {
                    MessageBox.Show("Username already exists. Please choose a different one.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
