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
            collection.AddScoped<IMain, Main>();
            var service = collection.BuildServiceProvider();
            var program = service.GetService<IMain>();
            program.Start();
        }
    }
}
