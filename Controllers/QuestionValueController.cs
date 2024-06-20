using Microsoft.AspNetCore.Mvc;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;

namespace QuestionnaireApp2.Controllers;

public class QuestionValueController:ControllerBase
{
    private readonly IQuestionValueRepository _questionValueRepository;


    public QuestionValueController(IQuestionValueRepository questionValueRepository)
    {
        _questionValueRepository = questionValueRepository;

    }
    
    [HttpPost("CreateQuestionsValue")]
    public async Task<ActionResult> CreateQuestionsValue([FromBody] QuestionValues dto)
    {

        try
        {
            var data = await _questionValueRepository.CreateQuestionsValue(dto);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        

    }
    
    [HttpPut("UpdateQuestionValue/{id}/{partitionKey}")]
    public async Task<ActionResult> UpdateQuestionValue(string id, string partitionKey, [FromBody] QuestionValues dto)
    {
        if (id != dto.id || partitionKey != dto.questionValuesId)
        {
            return BadRequest();
        }
        try
        {
            var data = await _questionValueRepository.UpdateQuestionValue(dto);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
    
    [HttpGet("GetQuestionsValueById/{id}")]
    public async Task<ActionResult> GetQuestionsValueById(string id)
    {
       
        try
        {
            var data = await _questionValueRepository.GetQuestionsValueById(id);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
    
    [HttpDelete("DeleteQuestionsValue/{id}/{partitionKey}")]
    public async Task<ActionResult> DeleteQuestionsValue(string id,string partitionKey)
    {
       
        try
        {
            var data = await _questionValueRepository.DeleteQuestionsValue(id,partitionKey);
            return Ok(data);
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }
}