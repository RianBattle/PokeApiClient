using Microsoft.Extensions.DependencyInjection;

namespace PokeApiClient.Infrastructure.DynamoDB {
    public static class DependencyInjection {
        public static IServiceCollection AddDynamoDBServices(this IServiceCollection services) {
            return services;
        }
    }
}
