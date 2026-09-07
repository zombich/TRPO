using DatabaseLibrary;
using DatabaseLibrary.Models;
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

namespace UsersApp
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
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserService.Users.FirstOrDefault(u=> u.Login == UserLoginTextBox.Text && u.Password == UserPasswordBox.Password) is not null)
            {
                UsersWindow usersWindow = new();
                Hide();
                usersWindow.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new();
            Hide();
            registrationWindow.ShowDialog();
            Show();
        }
    }
}