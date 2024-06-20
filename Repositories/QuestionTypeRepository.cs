using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Repositories;

public class QuestionTypeRepository(ICosmosDbService cosmosDbService): IQuestionTypeRepository
{
    public async Task<List<QuestionTypes>> GetQuestionTypes()
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();
            var container =  database?.GetContainer("QuestionTypes")!;
            var query = new QueryDefinition("SELECT * FROM c");

            var resultSetIterator = container.GetItemQueryIterator<QuestionTypes>(query);

            var results = new List<QuestionTypes>();
            while (resultSetIterator.HasMoreResults)
            {
                var response = await resultSetIterator.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}