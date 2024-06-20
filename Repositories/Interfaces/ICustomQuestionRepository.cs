using QuestionnaireApp2.Models;

namespace QuestionnaireApp2.Repositories.Interfaces;

public interface ICustomQuestionRepository
{
    Task<CustomQuestion> CreateCustomQuestions(CustomQuestion param);
    Task<CustomQuestion> UpdateCustomQuestion(CustomQuestion param);
    Task<List<GetCustomQuestion>> GetCustomQuestionByProgramId(string id);
    Task<string> DeleteCustomQuestion(string id,string partitionKey);
    
}