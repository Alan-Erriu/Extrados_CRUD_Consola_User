using DAO.Interfaces;
using DAO.Models;

namespace Extrados_CRUD_USERS
{
    public class UserManager
    {
        private readonly IUserData _userData;

        // en lugar de una clase, se solicita que cumpla con la interfaz
        public UserManager(IUserData userData)
        {
            _userData = userData;
        }

        public List<User> GetUsersOrderByAge()
        {
            var users = _userData.GetUsers();
            var usersOrdered = users.OrderBy(u => u.user_age).ToList();
            return usersOrdered;
        }


    }
}
