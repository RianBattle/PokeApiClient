using PokeApiClient.Infrastructure.DynamoDB;

PokeApiClientBlazorStartup blazorStartup = new PokeApiClientBlazorStartup(args, services => {
    services.AddDynamoDBServices();
});
