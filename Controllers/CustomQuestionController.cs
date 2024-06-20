using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;
using QuestionnaireApp2.Services;

namespace QuestionnaireApp2.Controllers;

public class CustomQuestionController:ControllerBase
{
    private readonly ICustomQuestionRepository _customQuestionRepository;


    public CustomQuestionController(ICustomQuestionRepository customQuestionRepository)
    {
        _customQuestionRepository = customQuestionRepository;

    }
    
    [HttpPost("CreateCustomQuestions")]
    public async Task<ActionResult> CreateCustomQuestions([FromBody] CustomQuestion dto)
    {

        try
        {
            var data = await _customQuestionRepository.CreateCustomQuestions(dto);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        

    }
    
    [HttpPut("UpdateCustomQuestion/{id}/{partitionKey}")]
    public async Task<ActionResult> UpdateCategory(string id, string partitionKey, [FromBody] CustomQuestion dto)
    {
        if (id != dto.id || partitionKey != dto.customQuestionId)
        {
            return BadRequest();
        }
        try
        {
            var data = await _customQuestionRepository.UpdateCustomQuestion(dto);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
    
    [HttpGet("GetCustomQuestionByProgramId/{id}")]
    public async Task<ActionResult> GetCustomQuestionByProgramId(string id)
    {
       
        try
        {
            var data = await _customQuestionRepository.GetCustomQuestionByProgramId(id);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
    
    [HttpDelete("DeleteCustomQuestion/{id}/{partitionKey}")]
    public async Task<ActionResult> DeleteCustomQuestion(string id,string partitionKey)
    {
       
        try
        {
            var data = await _customQuestionRepository.DeleteCustomQuestion(id,partitionKey);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
}
