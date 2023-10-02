using Autofac;
using Extrados_CRUD_USERS;



var container = IoC.Configure();
using (var scope = container.BeginLifetimeScope())
{
    var userManager = scope.Resolve<UserManager>();


    var usersOrderedByAge = userManager.GetUsersOrderByAge();


    foreach (var user in usersOrderedByAge)
    {
        Console.WriteLine($"Nombre: {user.user_name}, Edad: {user.user_age}");
    }
}

