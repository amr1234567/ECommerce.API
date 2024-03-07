
namespace ECommerce.Core.ConfigModels
{
    public class JwtConfigModel
    {
        public string audience { get; set; }
        public int expirePeriod { get; set; }
        public string issuer { get; set; }
        public string Key { get; set; }
    }

}
