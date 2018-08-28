using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageTableIdentity
{
    public class SiteUserAccess<T> : ISiteUserAccess<T> where T : class, ITableEntity
    {
        private readonly CloudTable _table;
        private readonly string _identityPartitionKey;

        public SiteUserAccess(string connectionString, string tableName, string identityPartitionKey)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            _identityPartitionKey = identityPartitionKey;
            _table = table;
        }

        public Task<T> FindByNameAsync(string normalizedUserName)
        {
            var retrieve = TableOperation.Retrieve<T>(_identityPartitionKey, normalizedUserName);
            var result = _table.ExecuteAsync(retrieve);
            return Task.FromResult(result.Result.Result as T);
        }
    }
}
