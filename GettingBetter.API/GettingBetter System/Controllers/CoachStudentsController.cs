using System.Net.Mime;
using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/coaches/{coachId}/students")]
[Produces(MediaTypeNames.Application.Json)]
public class CoachStudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;

    public CoachStudentsController(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Students for given Coach",
        Description = "Get existing Students associated with the specified Coach",
        OperationId = "GetCoachStudents",
        Tags = new[] { "Coaches" }
        )]
    public async Task<IEnumerable<StudentResource>> GetAllByCoachIdAsync(int coachId)
    {
        var students = await _studentService.ListByCoachIdAsync(coachId);

        var resources = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);

        return resources;
    }
}