using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageTableIdentity.Models
{
    public class SiteUser : TableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string NormalizedUserName { get; set; }

        public SiteUser(string name, string partitionKey, string id)
        {
            Id = id;
            Name = name;
            RowKey = name.ToUpper();
            PartitionKey = partitionKey;
        }

        public SiteUser()
        {
        }
    }
}
