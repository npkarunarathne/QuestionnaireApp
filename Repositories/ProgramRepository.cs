using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Repositories;

public class ProgramRepository(ICosmosDbService cosmosDbService) : IProgramRepository
{
    public async Task<Programs> Create(Programs param)
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();

            var container =  database?.GetContainer("Programs")!;
        
            Programs createdItem = await container.UpsertItemAsync<Programs>(
                item: param,
                partitionKey: new PartitionKey(param.programId)
            );

            await CreatePersonalInformationFields(param.programId);

            return createdItem;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<Programs> Update(Programs param)
    {
        var database = await cosmosDbService.GetDatabaseAsync();

        var container =  database?.GetContainer("Programs")!;
        
        Programs updatedItem = await container.UpsertItemAsync<Programs>(
            item: param,
            partitionKey: new PartitionKey(param.programId)
        );

        return updatedItem;
    }

    public async Task<Programs> GetById(string id)
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();

            var container =  database?.GetContainer("Programs")!;
            
            var response = await container.ReadItemAsync<Programs>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Programs> Delete(string id)
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();

            var container =  database?.GetContainer("Programs")!;
            
            var response = await container.DeleteItemAsync<Programs>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<List<PersonalInformationFields>> CreatePersonalInformationFields(string programId)
    {
        try
        {
            var database = await cosmosDbService.GetDatabaseAsync();

        var container =  database?.GetContainer("PersonalInformationFields")!;

        var personalInformationFields = new List<PersonalInformationFields>
        {
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = true,
                name = "First Name",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "pppppppp-3285-4550-a396-85a10fb79dff",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = true,
                name = "Last Name",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "pppppppp-3285-4550-a396-85a10fb79dff",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = true,
                name = "Email",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "pppppppp-3285-4550-a396-85a10fb79dff",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = false,
                name = "Phone",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "nnnnnnnn-1b7e-41c5-9632-98523c10da9d", 
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = false,
                name = "Nationality",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "dddddddd-4243-4bb9-adf3-1e8cd04d7722",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = false,
                name = "Current Residence",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "dddddddd-4243-4bb9-adf3-1e8cd04d7722",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = false,
                name = "Id Number",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "pppppppp-3285-4550-a396-85a10fb79dff",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = false,
                name = "Date of Birth",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "dddddddd-27d5-4b79-9543-c2c7e606fb4d",
                programId = programId
            },
            new()
            {
                id = Guid.NewGuid().ToString(),
                isHidden = false,
                isInternal = false,
                isMandatory = false,
                name = "Gender",
                personalInformationFieldId = Guid.NewGuid().ToString(),
                typeId = "dddddddd-4243-4bb9-adf3-1e8cd04d7722",
                programId = programId
            }
        };
        
        foreach (var personalInformationField in personalInformationFields)
        {
            await container.UpsertItemAsync(personalInformationField, new PartitionKey(personalInformationField.personalInformationFieldId));
        }

        return personalInformationFields;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}