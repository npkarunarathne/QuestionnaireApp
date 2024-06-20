using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class QuestionTypes
{
    [Key]
    public string id { get; set; }
    public string questionTypeId { get; set; }
    public string? name { get; set; }
    public bool hasValues { get; set; } 
    
}