using System.Net.Mime;
using AutoMapper;
using LearningCenter.API.GettingBetter_System.Domain.Services;
using LearningCenter.API.GettingBetter_System.Resources;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;

using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Cybers")]

public class CybersController : ControllerBase
{
    private readonly ICyberService _cyberService;
    private readonly IMapper _mapper;
    

    public CybersController(ICyberService cyberService, IMapper mapper)
    {
        _cyberService = cyberService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CyberResource>), 200)]
    public async Task<IEnumerable<CyberResource>> GetAllAsync()
    {
        var cybers = await _cyberService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Cyber>, IEnumerable<CyberResource>>(cybers);

        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CyberResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerResponse(201, "The cyber was successfully created.", typeof(CyberResource))]
    [SwaggerResponse(400, "The cyber data is not valid.")]
    public async Task<IActionResult> PostAsync([FromBody] SaveCyberResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cyber = _mapper.Map<SaveCyberResource, Cyber>(resource);

        var result = await _cyberService.SaveAsync(cyber);

        if (!result.Success)
            return BadRequest(result.Message);

        var cyberResource = _mapper.Map<Cyber, CyberResource>(result.Resource);

        return Ok(cyberResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCyberResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var cyber = _mapper.Map<SaveCyberResource, Cyber>(resource);
        var result = await _cyberService.UpdateAsync(id, cyber);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var cyberResource = _mapper.Map<Cyber, CyberResource>(result.Resource);

        return Ok(cyberResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cyberService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var cyberResource = _mapper.Map<Cyber, CyberResource>(result.Resource);

        return Ok(cyberResource);
    }
}