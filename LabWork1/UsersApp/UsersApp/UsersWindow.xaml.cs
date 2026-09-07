using DatabaseLibrary;
using Microsoft.Win32;
using System.Windows;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON файл |*.json";

            if (saveFileDialog.ShowDialog() is false)
                return;

            UserService.ExportUsers(UserService.Users, saveFileDialog.FileName);
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON файл |*.json";

            if (openFileDialog.ShowDialog() is false)
                return;

            UserService.ImportUsers(openFileDialog.FileName);

            GetUsers();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetUsers();
        }

        private void GetUsers()
        {
            UsersDataGrid.ItemsSource = UserService.Users;
        }
    }
}
