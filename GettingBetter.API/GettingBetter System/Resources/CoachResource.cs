using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Resources;

public class CoachResource
{
    [SwaggerSchema("Coach Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Coach Name")]
    public string Name { get; set; }
}