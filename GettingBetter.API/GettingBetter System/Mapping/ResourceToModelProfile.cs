using AutoMapper;
using LearningCenter.API.GettingBetter_System.Resources;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCoachResource, Coach>();
        CreateMap<SaveStudentResource, Student>();
    }
}