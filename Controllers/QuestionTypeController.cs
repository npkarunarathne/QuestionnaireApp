using Microsoft.AspNetCore.Mvc;
using QuestionnaireApp2.Repositories.Interfaces;

namespace QuestionnaireApp2.Controllers;

public class QuestionTypeController(IQuestionTypeRepository questionTypeRepository): ControllerBase
{
    [HttpGet("GetQuestionTypes")]
    public async Task<ActionResult> GetQuestionTypes()
    {
        try
        {
            var result = await questionTypeRepository.GetQuestionTypes();
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }
}