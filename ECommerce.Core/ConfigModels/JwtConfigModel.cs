
namespace ECommerce.Core.ConfigModels
{
    public class JwtConfigModel
    {
        public string audience { get; set; }
        public int expirePeriodInMinuts { get; set; }
        public string issuer { get; set; }
        public string Key { get; set; }
        public int RefreshExpiredPeriodInDays { get; set; }
    }


}
