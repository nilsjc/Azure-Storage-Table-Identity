using AzureStorageTableIdentity.Models;
using AzureStorageTableIdentity.Statics;
using Microsoft.AspNetCore.Identity;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorageTableIdentity.Services
{
    public class SiteUserStore : IUserPasswordStore<SiteUser>
    {
        private readonly CloudTable _table;

        public SiteUserStore(string connectionString, string tableName)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            _table = table;
        }

        public void Dispose()
        {
        }

        public Task<string> GetUserIdAsync(SiteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(SiteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public Task SetUserNameAsync(SiteUser user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(SiteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetNormalizedUserNameAsync(SiteUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> CreateAsync(SiteUser user, CancellationToken cancellationToken)
        {
            try
            {
                var insert = TableOperation.Insert(user);
                await _table.ExecuteAsync(insert);
                return IdentityResult.Success;
            }
            catch
            {
                return IdentityResult.Failed();
            }
        }

        public Task<IdentityResult> UpdateAsync(SiteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(SiteUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SiteUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            TableOperation op = TableOperation.Retrieve<SiteUser>(PartitionKey.Name, userId);
            var result = _table.ExecuteAsync(op);
            return Task.FromResult(result.Result.Result as SiteUser);
        }

        public Task<SiteUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var retrieve = TableOperation.Retrieve<SiteUser>(PartitionKey.Name, normalizedUserName);
            var result = _table.ExecuteAsync(retrieve);
            return Task.FromResult(result.Result.Result as SiteUser);
        }

        public Task SetPasswordHashAsync(SiteUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(SiteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(SiteUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
}
