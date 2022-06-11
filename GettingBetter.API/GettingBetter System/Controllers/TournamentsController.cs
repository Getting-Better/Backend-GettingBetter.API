using System.Net.Mime;
using AutoMapper;
using LearningCenter.API.GettingBetter_System.Domain.Services;
using LearningCenter.API.GettingBetter_System.Resources;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.GettingBetter_System.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Tournaments")]

public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _tournamentService;
    private readonly IMapper _mapper;
    

    public TournamentsController(ITournamentService tournamentService, IMapper mapper)
    {
        _tournamentService = tournamentService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TournamentResource>), 200)]
    public async Task<IEnumerable<TournamentResource>> GetAllAsync()
    {
        var tournaments = await _tournamentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentResource>>(tournaments);

        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TournamentResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerResponse(201, "The coach was successfully created.", typeof(TournamentResource))]
    [SwaggerResponse(400, "The coach data is not valid.")]
    public async Task<IActionResult> PostAsync([FromBody] SaveTournamentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tournament = _mapper.Map<SaveTournamentResource, Tournament>(resource);

        var result = await _tournamentService.SaveAsync(tournament);

        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);

        return Created(nameof(PostAsync),tournamentResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTournamentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var tournament = _mapper.Map<SaveTournamentResource, Tournament>(resource);
        var result = await _tournamentService.UpdateAsync(id, tournament);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tournamentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);

        return Ok(tournamentResource);
    }
    
}
