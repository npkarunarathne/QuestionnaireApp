using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class PersonalInformationResponses
{
    [Key]
    public string id { get; set; }
    public string personalInformationResponsesId { get; set; }
    public string? responseId { get; set; } 
    public string? fieldId { get; set; }
    public string? fieldValue { get; set; }

}