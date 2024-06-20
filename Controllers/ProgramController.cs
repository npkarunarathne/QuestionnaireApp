using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuestionnaireApp2.Models;
using QuestionnaireApp2.Repositories.Interfaces;

namespace QuestionnaireApp2.Controllers;

public class ProgramController(IProgramRepository programRepository):ControllerBase
{
    [HttpPost("Create")]
    public async Task<ActionResult> Create([FromBody] Programs dto)
    {
        try
        {
            var result = await programRepository.Create(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }
    
    [HttpGet("GetById/{id}")]
    public async Task<ActionResult> Get(string id)
    {
        try
        {
            var result = await programRepository.GetById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }
    
    [HttpPut("Update")]
    public async Task<ActionResult> Update([FromBody] Programs dto)
    {
        try
        {
            var result = await programRepository.Update(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }
    
    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        try
        {
            var result = await programRepository.Delete(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }
}