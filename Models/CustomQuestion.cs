using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class CustomQuestion
{
    [Key]
    public string id { get; set; }
    public string customQuestionId { get; set; }
    public string? name { get; set; }
    public string? type { get; set; } 
    public string programId { get; set; }
    
}

public class GetCustomQuestion
{
    [Key]
    public string id { get; set; }
    public string customQuestionId { get; set; }
    public string? name { get; set; }
    public string? type { get; set; } 
    public string programId { get; set; }
    public List<QuestionValues> questionValues { get; set; }

}