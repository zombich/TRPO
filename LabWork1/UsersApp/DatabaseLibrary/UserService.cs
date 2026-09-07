using DatabaseLibrary.Models;
using System.Text.Json;

namespace DatabaseLibrary
{
    public static class UserService
    {
        public static List<User> Users { get; private set; } = ImportUsersFromJson(GetUsersFilePath());
        public static void ExportUsersToJson(List<User> users, string path)
        {
            var data = JsonSerializer.Serialize(users);

            File.WriteAllText(path, data);
        }

        public static List<User> ImportUsersFromJson(string filePath)
        {
            var data = File.ReadAllText(filePath);

            var users = JsonSerializer.Deserialize<List<User>>(data);

            return users;
        }
        public static void AddNewUser(User user)
        {
            Users.Add(user);
            ExportUsersToJson(Users, GetUsersFilePath());
        }

        public static string GetUsersFilePath() => Path.Combine(Environment.CurrentDirectory, "users.json");
    }
}
