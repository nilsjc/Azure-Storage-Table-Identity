using AzureStorageTableIdentity.Interfaces;
using AzureStorageTableIdentity.Models;
using AzureStorageTableIdentity.Statics;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AzureStorageTableIdentity.Services
{
    public class UserFactory : IUserFactory
    {
        private readonly UserManager<SiteUser> _userManager;

        public UserFactory(UserManager<SiteUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                user = new SiteUser(model.UserName, PartitionKey.Name, model.Id);
                var result = await _userManager.CreateAsync(user, model.Password);
                return result.ToString();
            }
            return "Name already exists";
        }
    }
}
