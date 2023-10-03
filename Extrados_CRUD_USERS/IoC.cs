using Autofac;
using DAOUser.Data;
using DAOUser.Interfaces;

namespace Extrados_CRUD_USERS
{
    public class IoC
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<UserData>().As<IUserData>();


            builder.RegisterType<UserManager>().As<UserManager>();

            return builder.Build();
        }
    }
}
