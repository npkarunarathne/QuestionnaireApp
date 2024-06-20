using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;

namespace QuestionnaireApp2.Services;

public class CosmosDbService:ICosmosDbService
{

    private readonly IConfiguration _configuration;
    
    public CosmosDbService(IConfiguration configuration) 
    {
        _configuration = configuration;

    }
    
    private Database? _database;
    private async Task InitializeAsync()
    {
        var cosmosClient = new CosmosClient(
            accountEndpoint:_configuration.GetValue<string>("accountEndpoint"),
            authKeyOrResourceToken:
            _configuration.GetValue<string>("authKeyOrResourceToken")
        );

        _database ??= await cosmosClient.CreateDatabaseIfNotExistsAsync(_configuration.GetValue<string>("Database"));
    }

    public async Task<Database?> GetDatabaseAsync()
    {
        await InitializeAsync();
        return _database;
    }

    private async Task<Container> GetContainerAsync(string containerId, string partitionKeyPath)
    {
        await GetDatabaseAsync();
        Container container = await _database.CreateContainerIfNotExistsAsync(containerId, partitionKeyPath);
        return container;
    }
    public async Task SeedDataAsync()
    {
        var CustomQuestion = await GetContainerAsync("CustomQuestion","/customQuestionId");
        var CustomQuestionResponses = await GetContainerAsync("CustomQuestionResponses","/customQuestionResponsesId");
        var PersonalInformationFields = await GetContainerAsync("PersonalInformationFields","/personalInformationFieldId");
        var PersonalInformationResponses = await GetContainerAsync("PersonalInformationResponses","/personalInformationResponsesId");
        var Programs = await GetContainerAsync("Programs","/programId");
        var QuestionTypes = await GetContainerAsync("QuestionTypes","/questionTypeId");
        var QuestionValues = await GetContainerAsync("QuestionValues","/questionValuesId");
        var Responses = await GetContainerAsync("Responses","/responsesId");

        var questionTypes = new List<QuestionTypes>
        {
            new QuestionTypes{id = "9ea1a9da-3285-4550-a396-85a10fb79dff",questionTypeId = "pppppppp-3285-4550-a396-85a10fb79dff", name = "Paragraph", hasValues = false},
            new QuestionTypes{id = "1fdd811a-8295-4a17-bcb4-23ee0ee8a3b3",questionTypeId = "yyyynnnnn-8295-4a17-bcb4-23ee0ee8a3b3", name = "Yes/No", hasValues = false},
            new QuestionTypes{id = "eba711bb-4243-4bb9-adf3-1e8cd04d7722",questionTypeId = "dddddddd-4243-4bb9-adf3-1e8cd04d7722", name = "Dropdown", hasValues = true},
            new QuestionTypes{id = "22ef9236-27d5-4b79-9543-c2c7e606fb4d",questionTypeId = "dddddddd-27d5-4b79-9543-c2c7e606fb4d", name = "Date", hasValues = false},
            new QuestionTypes{id = "35c29351-1b7e-41c5-9632-98523c10da9d",questionTypeId = "nnnnnnnn-1b7e-41c5-9632-98523c10da9d", name = "Number", hasValues = false}
        };
        
        foreach (var questionType in questionTypes)
        {
            await QuestionTypes.UpsertItemAsync(questionType, new PartitionKey(questionType.questionTypeId));
        }
    }
    
}
