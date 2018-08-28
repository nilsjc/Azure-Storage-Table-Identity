using AzureStorageTableIdentity.Interfaces;
using AzureStorageTableIdentity.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace AzureStorageTableIdentity.Services
{
    class ListUsers : IListUsers
    {
        private const string IdPropertyName = "Id";
        private readonly CloudTable _table;

        public ListUsers(string storageConnectionKey, string tableName)
        {
            CloudStorageAccount storeAccount = CloudStorageAccount.Parse(storageConnectionKey);
            CloudTableClient tableClient = storeAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(tableName);
        }

        public List<SiteUser> ListAllById(String id)
        {
            var query = new TableQuery<SiteUser>().Where(TableQuery.GenerateFilterCondition(IdPropertyName, QueryComparisons.Equal, id));
            var result = _table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());
            var results = new List<SiteUser>();
            results.AddRange(result.Result.Results);
            return results;
        }
    }
}
