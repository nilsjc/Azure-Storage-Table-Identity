using AzureStorageTableIdentity.Models;
using System.Threading.Tasks;

namespace AzureStorageTableIdentity.Interfaces
{
    public interface IUserFactory
    {
        Task<string> RegisterAsync(RegisterModel model);
    }
}
