using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Resources;

public class TournamentResource
{
    [SwaggerSchema("Tournament Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Tournament Title")]
    public string Title{ get; set; }
    [SwaggerSchema("Tournament Description")]
    public string Description { get; set; }
    [SwaggerSchema("Tournament StudentId")]
    public int StudentId { get; set; }
    [SwaggerSchema("Tournament CyberId")]
    public int CyberId { get; set; }
    [SwaggerSchema("Tournament Date")]
    public string Date { get; set; }  
}