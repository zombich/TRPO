using DatabaseLibrary;
using DatabaseLibrary.Models;
using System.Windows;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginTextBox.Text;
            var password = UserPasswordBox.Password;
            var phone = PhoneTextBox.Text;
            var email = EmailTextBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
                return;

            var user = new User() { Email = email, Password = password, Phone = phone, Login = login };

            try
            {
                UserService.AddNewUser(user);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
