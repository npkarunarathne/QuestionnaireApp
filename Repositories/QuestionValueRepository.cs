using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Repositories;

public class QuestionValueRepository:IQuestionValueRepository
{
    
    private readonly IConfiguration _configuration;
    private readonly ICosmosDbService _cosmosDbService;

    
    public QuestionValueRepository(IConfiguration configuration,ICosmosDbService cosmosDbService) 
    {
        _configuration = configuration;
        _cosmosDbService = cosmosDbService;

    }
    public async Task<QuestionValues> CreateQuestionsValue(QuestionValues? data)
    {
        try
        {
            if (data != null)
            {
                var database = await _cosmosDbService.GetDatabaseAsync();

                if (database != null)
                {
                    Container container = await database.CreateContainerIfNotExistsAsync("QuestionValues","/questionValuesId");
                    
                    data.id = Guid.NewGuid().ToString();
                    data.questionValuesId = Guid.NewGuid().ToString();
                    
                    await container.CreateItemAsync(data, new PartitionKey(data.questionValuesId));

                }
                
                return data;

            }
            else
            {
                throw new Exception("insert data was null");
            }

        }
        catch (Exception ex)
        {
            throw ex;

        }    }

    public async Task<QuestionValues> UpdateQuestionValue(QuestionValues? data)
    {
        try
        {
            if (data != null)
            {
                var database = await _cosmosDbService.GetDatabaseAsync();

                if (database != null)
                {
                    Container container = await database.CreateContainerIfNotExistsAsync("QuestionValues","/questionValuesId");
                    
                    await container.UpsertItemAsync(data, new PartitionKey(data.questionValuesId));

                }
                
                return data;

            }
            else
            {
                throw new Exception("insert data was null");
            }

        }
        catch (Exception ex)
        {
            throw ex;

        }    }

    public async Task<List<QuestionValues>> GetQuestionsValueById(string id)
    {
        try
        {
            
            var database = await _cosmosDbService.GetDatabaseAsync();
            var results = new List<QuestionValues>();

            if (database != null)
            {
                Container container = await database.CreateContainerIfNotExistsAsync("QuestionValues","/questionValuesId");
                    
                var query = new QueryDefinition("SELECT * FROM c WHERE c.questionId = @id").WithParameter("@id", id);
                    
                var resultSet = container.GetItemQueryIterator<QuestionValues>(query);
                    
                while (resultSet.HasMoreResults)
                {
                    var response = await resultSet.ReadNextAsync();
                    results.AddRange(response.ToList());
                }
            }
                
            
            return results;

        }
        catch (Exception ex)
        {
            throw ex;

        }    }

    public async Task<string> DeleteQuestionsValue(string id, string partitionKey)
    {
        try
        {
            var database = await _cosmosDbService.GetDatabaseAsync();

            if (database != null)
            {
                Container container = await database.CreateContainerIfNotExistsAsync("QuestionValues","/questionValuesId");
                
                await container.DeleteItemAsync<Category>(id, new PartitionKey(partitionKey));
                
            }
            
            return id;

        }
        catch (Exception ex)
        {
            throw ex;

        }
        
    }
}