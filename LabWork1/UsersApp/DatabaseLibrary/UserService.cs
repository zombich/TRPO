using DatabaseLibrary.Models;
using System.Text.Json;

namespace DatabaseLibrary
{
    public static class UserService
    {
        public static List<User> Users { get; private set; } = GetUsersFromJson(GetUsersFilePath());
        public static void ExportUsers(List<User> users, string path)
        {
            var data = JsonSerializer.Serialize(users);

            File.WriteAllText(path, data);
        }

        public static List<User> GetUsersFromJson(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return new List<User>();

                var data = File.ReadAllText(filePath);

                var users = JsonSerializer.Deserialize<List<User>>(data);

                return users;
            }
            catch
            {
                return new List<User>();
            }
        }

        public static void AddNewUser(User user)
        {
            if (Users.FirstOrDefault(u => u.Email == user.Email || u.Login == user.Login || u.Phone == user.Phone) is not null)
                throw new Exception("Пользователь уже существует");

            Users.Add(user);
            ExportUsers(Users, GetUsersFilePath());
        }

        public static string GetUsersFilePath() => Path.Combine(Environment.CurrentDirectory, "users.json");

        public static void ImportUsers(string filePath)
        {
            Users = GetUsersFromJson(filePath);
            ExportUsers(Users, GetUsersFilePath());
        }
    }
}
