using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Resources;

[SwaggerSchema(Required = new []{"Title","Description","StudentId","CyberId","Date"})]

public class SaveTournamentResource
{

    [SwaggerSchema("Tournament Title")]
    [Required]
    public string Title{ get; set; }
    
    [SwaggerSchema("Tournament Description")]
    [Required]
    public string Description { get; set; }
    
    [SwaggerSchema("Tournament StudentId")]
    [Required]
    public int StudentId { get; set; }
    
    [SwaggerSchema("Tournament CyberId")]
    [Required]
    public int CyberId { get; set; }
    
    [Required]
    [SwaggerSchema("Tournament Date")]
    public string Date { get; set; }  
}
