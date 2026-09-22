using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using Task1DatabaseLibrary.Models;

namespace Task3Client.ViewModels
{
    public partial class ApplicationViewModel : ObservableObject
    {
        public ObservableCollection<Student> Students { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();
        

        [RelayCommand]
        private async Task GetStudentsAsync()
        {
            using var client = new HttpClient();

            var studentsRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5289/api/Students");
            using var studentsResponse = await client.SendAsync(studentsRequest);
            var students = await studentsResponse.Content.ReadFromJsonAsync<List<Student>>();

            Students.Clear();
            foreach (var student in students)
                Students.Add(student);

            var categoriesRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5289/api/Categories");
            using var categoriesResponse = await client.SendAsync(categoriesRequest);
            var categories = await categoriesResponse.Content.ReadFromJsonAsync<List<Category>>();

            Categories.Clear();
            foreach (var category in categories)
                Categories.Add(category);
        }
    }
}
