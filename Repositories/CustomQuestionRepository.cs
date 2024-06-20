using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Repositories;

public class CustomQuestionRepository:ICustomQuestionRepository
{
    
    private readonly IConfiguration _configuration;
    private readonly ICosmosDbService _cosmosDbService;
    private readonly IQuestionValueRepository _questionValueRepository;

    
    public CustomQuestionRepository(IConfiguration configuration,ICosmosDbService cosmosDbService,IQuestionValueRepository questionValueRepository) 
    {
        _configuration = configuration;
        _cosmosDbService = cosmosDbService;
        _questionValueRepository = questionValueRepository;

    }
    public async Task<CustomQuestion> CreateCustomQuestions(CustomQuestion? data)
    {
        try
        {
            if (data != null)
            {
                var database = await _cosmosDbService.GetDatabaseAsync();

                if (database != null)
                {
                    Container container = await database.CreateContainerIfNotExistsAsync("CustomQuestion", "/customQuestionId");
                    
                    data.id = Guid.NewGuid().ToString();
                    data.customQuestionId = Guid.NewGuid().ToString();
                    
                    await container.CreateItemAsync(data, new PartitionKey(data.customQuestionId));

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

        }
    }

    
    public async Task<CustomQuestion> UpdateCustomQuestion(CustomQuestion? data)
    {
        try
        {
            if (data != null)
            {
                var database = await _cosmosDbService.GetDatabaseAsync();

                if (database != null)
                {
                    Container container = await database.CreateContainerIfNotExistsAsync("CustomQuestion", "/customQuestionId");
                    
                    await container.UpsertItemAsync(data, new PartitionKey(data.customQuestionId));

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

        }
    }

    public async Task<List<GetCustomQuestion>> GetCustomQuestionByProgramId(string id)
    {
        try
        {
            
                var database = await _cosmosDbService.GetDatabaseAsync();
                var results = new List<GetCustomQuestion>();

                if (database != null)
                {
                    Container container = await database.CreateContainerIfNotExistsAsync("CustomQuestion", "/customQuestionId");
                    
                    var query = new QueryDefinition("SELECT * FROM c WHERE c.programId = @id").WithParameter("@id", id);
                    
                    var resultSet = container.GetItemQueryIterator<GetCustomQuestion>(query);
                    
                    while (resultSet.HasMoreResults)
                    {
                        var response = await resultSet.ReadNextAsync();
                        results.AddRange(response.ToList());
                        
                    }
                }

                foreach (var item in results)
                {
                    item.questionValues = _questionValueRepository.GetQuestionsValueById(item.id).Result;
                }
            
                return results;

        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    
    public async Task<string> DeleteCustomQuestion(string id,string partitionKey)
    {
        try
        {
            var database = await _cosmosDbService.GetDatabaseAsync();

            if (database != null)
            {
                Container container = await database.CreateContainerIfNotExistsAsync("CustomQuestion", "/customQuestionId");
                
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