using System.ComponentModel.DataAnnotations;

namespace AzureStorageTableIdentity.Models
{
    public class RegisterModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
