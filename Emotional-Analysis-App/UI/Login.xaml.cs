using API;
using HandyControl.Controls;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : System.Windows.Window
    {
        public Login()
        {
            InitializeComponent();

        }

        private void JumpRegist(object sender, RoutedEventArgs e)
        {
            if (registSwitch.IsOn == true)
            {
                Register register = new Register();
                register.Show();
                loginWindow.IsEnabled = false;
            }
        }

        private async void UserLoginAsync(object sender, RoutedEventArgs e)
        {

            string username = usernameBox.Text;
            string password = passwordBox.Password;
            //登录用户
            //在数据库中查找用户
            //如果用户存在则登录成功
            //如果密码错误则提示用户密码错误
            //如果用户不存在则提示用户用户不存在
            using (var _dbContext = new EmotionDbContext())
            {
                IUserRepository userRepository = new UserRepository(_dbContext);
                var user = await userRepository.LoginUserAsync(username, password);
                if (user != null)
                {
                    MessageBox.Show("Login successful!");
                    // Navigate to the next window
                    UserInterface userInterface = new UserInterface();
                    userInterface.Show();
                    Tag tagUserName = userInterface.FindName("username") as Tag;
                    if (tagUserName != null)
                    {
                        tagUserName.Content = username;
                    }
                    loginWindow.Close();
                    //登录成功后关闭窗口
                    //并打开用户界面
                    //设置用户界面的用户名(此部分代码已经写好)
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your credentials.");
                }
            }
        }
    }
}