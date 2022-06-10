using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Resources;

[SwaggerSchema(Required = new []{"Name"})]
public class SaveCoachResource
{
    [SwaggerSchema("Coach Name")]
    [Required]
    public string Name { get; set; }
}