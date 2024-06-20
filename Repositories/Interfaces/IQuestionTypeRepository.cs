using QuestionnaireApp2.Models;

namespace QuestionnaireApp2.Repositories.Interfaces;

public interface IQuestionTypeRepository
{
    Task<List<QuestionTypes>> GetQuestionTypes();
}