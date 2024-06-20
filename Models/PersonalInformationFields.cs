using System.ComponentModel.DataAnnotations;

namespace QuestionnaireApp2.Models;

public class PersonalInformationFields
{
    [Key]
    public string id { get; set; }
    public string? personalInformationFieldId { get; set; }
    public string? name { get; set; }
    public bool isHidden { get; set; } 
    public bool isInternal { get; set; } 
    public bool isMandatory { get; set; }
    public string typeId { get; set; }
    public string programId { get; set; }

}