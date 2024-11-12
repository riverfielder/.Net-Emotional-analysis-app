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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void loginJump(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
        }


        private void registJump(object sender, RoutedEventArgs e)
        {
            Regist regist = new Regist();
            regist.Show();
        }
    }
}