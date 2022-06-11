using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Resources;

public class CyberResource
{
    [SwaggerSchema("Cyber Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Cyber FirstName")]
    public string FirstName { get; set; }
    [SwaggerSchema("Cyber LastName")]
    public string LastName { get; set; }
    [SwaggerSchema("Cyber CyberName")]
    public string CyberName{ get; set; }
    [SwaggerSchema("Cyber Bibliography")]
    public string Bibliography { get; set; }
    [SwaggerSchema("Cyber Address")]
    public string Address { get; set; }
    [SwaggerSchema("Cyber Email")] 
    public string Email { get; set; }
    [SwaggerSchema("Cyber Password")]
    public string Password { get; set; }
}