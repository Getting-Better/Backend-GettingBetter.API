using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Resources;
[SwaggerSchema(Required = new []{"FirstName","LastName","CyberName","Bibliography","Address","Email","Password"})]
public class SaveCyberResource
{
   
    [SwaggerSchema("Cyber FirstName")]
    [Required]
    public string FirstName { get; set; }
    [SwaggerSchema("Cyber LastName")]
    [Required]
    public string LastName { get; set; }
    [SwaggerSchema("Cyber CyberName")]
    [Required]
    public string CyberName{ get; set; }
    [SwaggerSchema("Cyber Bibliography")]
    [Required]
    public string Bibliography { get; set; }
    [SwaggerSchema("Cyber Address")]
    [Required]
    public string Address { get; set; }
    [SwaggerSchema("Cyber Email")]
    [Required]
    public string Email { get; set; }
    
    [SwaggerSchema("Cyber Password")]
    [Required]
    public string Password { get; set; }
}