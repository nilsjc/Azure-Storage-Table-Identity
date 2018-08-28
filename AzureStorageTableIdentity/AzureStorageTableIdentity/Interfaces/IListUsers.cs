using AzureStorageTableIdentity.Models;
using System.Collections.Generic;

namespace AzureStorageTableIdentity.Interfaces
{
    public interface IListUsers
    {
        List<SiteUser> ListAllById(string id);
    }
}
