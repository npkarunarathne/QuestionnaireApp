using QuestionnaireApp2.Models;

namespace QuestionnaireApp2.Repositories.Interfaces;

public interface IQuestionValueRepository
{
    Task<QuestionValues> CreateQuestionsValue(QuestionValues param);
    Task<QuestionValues> UpdateQuestionValue(QuestionValues param);
    Task<List<QuestionValues>> GetQuestionsValueById(string id);
    Task<string> DeleteQuestionsValue(string id,string partitionKey);
}