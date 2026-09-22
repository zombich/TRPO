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
using Task1DatabaseLibrary.Contexts;
using Task1DatabaseLibrary.Models;

namespace Task1Client
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StudentsContext studentsContext = new();
            //MessageBox.Show(studentsContext.Students.Count().ToString());
            //Category category1 = new() { Id = 1, Name = "Бюджетное" };
            //Category category2 = new() { Id = 2, Name = "Платное" };
            //Student student1 = new() { Id = 1, FullName = "Студентыч Студентов Студент", Birthday = DateOnly.FromDateTime(DateTime.Now), CategoryId = 1, Course = 3, IsScholarshipHolder = true };
            //Student student2 = new() { Id = 2, FullName = "Скебоб Чупеп", Birthday = DateOnly.Parse("20/10/2000"), CategoryId = 2, Course = 1, IsScholarshipHolder = true };
            //Student student3 = new() { Id = 3, FullName = "Щфлыв Фыв Фыв", Birthday = DateOnly.Parse("09/08/2002"), CategoryId = 1, Course = 4, IsScholarshipHolder = false };

            //studentsContext.Add(category1);
            //studentsContext.Add(category2);
            //studentsContext.Add(student1);
            //studentsContext.Add(student2);
            //studentsContext.Add(student3);

            //studentsContext.SaveChanges();
        }
    }
}