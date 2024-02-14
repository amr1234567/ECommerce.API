using StackExchange.Redis;

namespace ECommerce.APIProject.Config
{
    public static class RedisServices
    {
        public static IServiceCollection AddRedisServices(this IServiceCollection services,IConfiguration _configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var connection = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(connection);
            });

            return services;
        }
    }
}
