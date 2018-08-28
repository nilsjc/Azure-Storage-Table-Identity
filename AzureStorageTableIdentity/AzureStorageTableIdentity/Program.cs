using AzureStorageTableIdentity.Interfaces;
using AzureStorageTableIdentity.Models;
using AzureStorageTableIdentity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AzureStorageTableIdentity
{
    class Program
    {
        const string ConnectionStringKey = "";
        private const string TableName = "";

        static void Main(string[] args)
        {
            IServiceCollection collection = new ServiceCollection();

            collection.AddScoped<IUserStore<SiteUser>>(provider =>
                new SiteUserStore(ConnectionStringKey, TableName));

            collection.AddScoped<IListUsers>(provider =>
                new ListUsers(ConnectionStringKey, TableName));

            collection.AddScoped<IUserFactory, UserFactory>();
            collection.AddScoped<IUserClaimsPrincipalFactory<SiteUser>, SiteUserClaimsPrincipalFactory>();
            collection.AddSingleton<Client>();
            collection.AddIdentityCore<SiteUser>();

            var service = collection.BuildServiceProvider();
            var program = service.GetService<Client>();

            program.Start();
        }
    }
}
