namespace DAO.Interfaces
{
    internal interface IDataUser
    {
        void CreateUser(string name, int age);
        void DeleteUserById(int id);
        void Dispose();
        void GetUserById(int id);
        void getUsers();
        void UpdateUserById(int id, string name, int age);
    }
}