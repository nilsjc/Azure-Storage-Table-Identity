using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorageTableIdentity
{
    public interface ISiteUserAccess<T>
    {
        Task<T> FindByNameAsync(string normalizedUserName);
    }
}
