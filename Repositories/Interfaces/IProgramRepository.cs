using QuestionnaireApp2.Models;

namespace QuestionnaireApp2.Repositories.Interfaces;

public interface IProgramRepository
{
    Task<Programs> Create(Programs param);
    Task<Programs> Update(Programs param);
    Task<Programs> GetById(string id);
    Task<Programs> Delete(string id);
}