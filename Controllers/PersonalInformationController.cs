using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Controllers;

public class PersonalInformationController(
    IPersonalInformationRepository personalInformationRepository)
    : ControllerBase

    { 
        [HttpPost("UpdatePersonalInformationField")]
    public async Task<ActionResult> CreatePersonalInformationField([FromBody] List<PersonalInformationFields> dto)
    {
        try
        {
            var result = await personalInformationRepository.CreatePersonalInformationField(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        

    }
    
    [HttpGet("GetPersonalInformationFieldByProgram/{programId}")]
    public async Task<ActionResult> GetPersonalInformationFieldByProgram(string programId )
    {
        try
        {
            var result = await personalInformationRepository.GetPersonalInformationFieldByProgram(programId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        

    }
}
