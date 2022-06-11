using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Resources;

public class AdvisoryResource
{
    [SwaggerSchema("Advisory Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Advisory StudentId")] 
    public int StudentId { get; set; }
    [SwaggerSchema("Advisory CoachId")]
    public int CoachId { get; set; }
    [SwaggerSchema("Advisory Date")]
    public string Date { get; set; }
    
    
   
}