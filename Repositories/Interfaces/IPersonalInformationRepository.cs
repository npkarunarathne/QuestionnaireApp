using QuestionnaireApp2.Models;

namespace QuestionnaireApp2.Repositories.Interfaces;

public interface IPersonalInformationRepository
{
    Task<List<PersonalInformationFields>> CreatePersonalInformationField(List<PersonalInformationFields> param);
    Task<List<PersonalInformationFields>> GetPersonalInformationFieldByProgram(string programId);
}