using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class CustomQuestionResponses
{
    [Key]
    public string id { get; set; }
    public string customQuestionResponsesId { get; set; }
    public string? responseId { get; set; } 
    public string? questionId { get; set; }
    public string? questionValue { get; set; }
}