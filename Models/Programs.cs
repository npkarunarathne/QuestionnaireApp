using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class Programs
{
    [Key]
    public string id { get; set; }
    public string programId { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
}