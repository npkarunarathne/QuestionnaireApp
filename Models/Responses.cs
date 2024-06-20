using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class Responses
{
    [Key]
    public string id { get; set; }
    public string ResponsesId { get; set; }
    public DateTime? date { get; set; } 
    public string? programId { get; set; }

}