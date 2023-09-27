using DAO.Interfaces;
using DAO.Models;
using Dapper;
using System.Data.SqlClient;

namespace DAO.Data
{
    public class DataUser : IDisposable, IDataUser
    {

        private string connectionString = @"Data Source=DESKTOP-D5JMIHP\SQLEXPRESS;Initial Catalog=user;User ID=code;Password=1506;";

        private SqlConnection dbConnection;


        public DataUser()
        {
            dbConnection = new SqlConnection(connectionString);

        }

        //obtener todos los usuarios de la db
        public void getUsers()
        {
            using (dbConnection)
            {
                var sql = "SELECT user_id, user_name, user_age ,user_status FROM [user]";
                var lst = dbConnection.Query<User>(sql);
                foreach (var item in lst)
                {

                    Console.WriteLine($"codigo: {item.user_id} nombre: {item.user_name} edad: {item.user_age} status {item.user_status}");
                }
            }


        }
        //obtener usuario por id 


        public void GetUserById(int id)
        {

            using (dbConnection = new SqlConnection(connectionString))
            {
                var parameters = new { Id = id };
                var sql = "SELECT user_id, user_name, user_age, user_status FROM [user] WHERE user_id = @Id";
                var user = dbConnection.QueryFirstOrDefault<User>(sql, parameters);

                if (user != null)
                {
                    Console.WriteLine($"User ID: {user.user_id}, User Name: {user.user_name}, User Age: {user.user_age} status {user.user_status}");
                }
                else
                {
                    Console.WriteLine("Usuario no encontrado");
                }
            }
        }


        // crear usuario 


        public void CreateUser(string name, int age)
        {
            // Validar que la edad sea mayor a 0
            if (age < 0)
            {
                Console.WriteLine("La edad debe ser mayor a 0");
                return;
            }
            // Validar que el name no esté en blanco
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("El nombre no puede estar en blanco.");
                return;
            }

            using (dbConnection = new SqlConnection(connectionString))
            {
                var parameters = new { Name = name, Age = age };
                var sql = "INSERT INTO [user] (user_name, user_age) VALUES (@Name, @Age)";

                var rowsAffected = dbConnection.Execute(sql, parameters);
                Console.WriteLine($"{rowsAffected} fila afectada");
            }
        }



        //borrar usuario (logico)
        public void DeleteUserById(int id)
        {

            if (id <= 0)
            {
                Console.WriteLine("Id debe ser mayor a 0");
                return;
            }

            using (dbConnection = new SqlConnection(connectionString))
            {
                var parameters = new { Id = id };
                var sql = "UPDATE [user] SET user_status = 0 WHERE user_id = @Id";


                var rowsAffected = dbConnection.Execute(sql, parameters);
                Console.WriteLine($"{rowsAffected} fila afectada");
            }
        }


        //actualizar usuario


        public void UpdateUserById(int id, string name, int age)
        {
            // Validar que el id sea mayor a 0
            if (id <= 0)
            {
                Console.WriteLine("El Id debe ser mayor a 0.");
                return;
            }

            // Validar que la edad sea mayor a 0
            if (age <= 0)
            {
                Console.WriteLine("La edad debe ser mayor a 0.");
                return;
            }

            // Validar que el name no esté en blanco
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("El nombre no puede estar en blanco.");
                return;
            }

            using (dbConnection = new SqlConnection(connectionString))
            {
                var parameters = new { Id = id, Name = name, Age = age };
                var sql = "UPDATE [user] SET user_name = @Name, user_age = @Age WHERE user_id = @Id";

                var rowsAffected = dbConnection.Execute(sql, parameters);
                Console.WriteLine($"{rowsAffected} fila afectada");
            }
        }

        public void Dispose()
        {


            // Cierra la conexión en el método Dispose
            dbConnection.Dispose();


        }
    }
}
