using ECommerce.Core.Entities.Identity;

namespace ECommerce.InfaStructure.Services
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiredOn { get; set; }
    }
}