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
[SwaggerTag("Create, read, update and delete Advisories")]
public class AdvisoriesController : ControllerBase
{
    private readonly IAdvisoryService _advisoryService;
    private readonly IMapper _mapper;
    

    public AdvisoriesController(IAdvisoryService advisoryService, IMapper mapper)
    {
        _advisoryService = advisoryService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AdvisoryResource>), 200)]
    public async Task<IEnumerable<AdvisoryResource>> GetAllAsync()
    {
        var advisories = await _advisoryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Advisory>, IEnumerable<AdvisoryResource>>(advisories);

        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AdvisoryResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerResponse(201, "The advisory was successfully created.", typeof(AdvisoryResource))]
    [SwaggerResponse(400, "The advisory data is not valid.")]
    public async Task<IActionResult> PostAsync([FromBody] SaveAdvisoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var advisory = _mapper.Map<SaveAdvisoryResource, Advisory>(resource);

        var result = await _advisoryService.SaveAsync(advisory);

        if (!result.Success)
            return BadRequest(result.Message);

        var advisoryResource = _mapper.Map<Advisory, AdvisoryResource>(result.Resource);

        return Created(nameof(PostAsync),advisoryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdvisoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var advisory = _mapper.Map<SaveAdvisoryResource, Advisory>(resource);
        var result = await _advisoryService.UpdateAsync(id, advisory);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var advisoryResource = _mapper.Map<Advisory, AdvisoryResource>(result.Resource);

        return Ok(advisoryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _advisoryService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var advisoryResource = _mapper.Map<Advisory, AdvisoryResource>(result.Resource);

        return Ok(advisoryResource);
    }
}