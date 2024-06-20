using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class QuestionValues
{
    [Key]
    public string id { get; set; }
    public string questionValuesId { get; set; }
    public string? questionId { get; set; }
    public string? valueName { get; set; } 
    
}