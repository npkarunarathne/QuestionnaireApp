using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Repositories.Interfaces;

public class PersonalInformationRepository(ICosmosDbService cosmosDbService) : IPersonalInformationRepository
{
    public async Task<List<PersonalInformationFields>> CreatePersonalInformationField(List<PersonalInformationFields> paramList)
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();

            var container =  database?.GetContainer("PersonalInformationFields")!;
        
            var createdItems = new List<PersonalInformationFields>();

            foreach (var param in paramList)
            {
                PersonalInformationFields createdItem = await container.UpsertItemAsync<PersonalInformationFields>(
                    item: param,
                    partitionKey: new PartitionKey(param.personalInformationFieldId)
                );
                createdItems.Add(createdItem);
            }
            
            return createdItems;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    
    public async Task<List<PersonalInformationFields>> GetPersonalInformationFieldByProgram(string programId)
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();
            var container =  database?.GetContainer("PersonalInformationFields")!;
            var query = new QueryDefinition("SELECT * FROM c WHERE c.programId = @programId")
                .WithParameter("@programId", programId);

            var resultSetIterator = container.GetItemQueryIterator<PersonalInformationFields>(query);

            var results = new List<PersonalInformationFields>();
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