using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Resources;
[SwaggerSchema(Required = new []{"StudentId","CoachId","Date"})]
public class SaveAdvisoryResource
{
   
    [SwaggerSchema("Advisory StudentId")]
    [Required]
    public int StudentId { get; set; }
    
    [SwaggerSchema("Advisory CoachId")]
    [Required]
    public int CoachId { get; set; }
    
    [SwaggerSchema("Advisory Date")]
    [Required]
    public string Date { get; set; }
 
    
}

