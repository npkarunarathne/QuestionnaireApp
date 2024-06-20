using Microsoft.Azure.Cosmos;

namespace QuestionnaireApp2.Services;

public interface ICosmosDbService
{
    Task<Database?> GetDatabaseAsync();
    Task SeedDataAsync();

}