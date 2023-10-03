using DAOUser.Models;

namespace DAOUser.Interfaces
{
    public interface IUserData
    {
        void CreateUser(string name, int age);
        void DeleteUserById(int id);
        void Dispose();
        void GetUserById(int id);
        List<User> GetUsers();
        void UpdateUserById(int id, string name, int age);
    }
}
