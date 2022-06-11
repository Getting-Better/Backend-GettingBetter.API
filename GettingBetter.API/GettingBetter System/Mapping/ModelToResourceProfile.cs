using AutoMapper;
using LearningCenter.API.GettingBetter_System.Resources;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.GettingBetter_System.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Coach, CoachResource>();
        CreateMap<Student, StudentResource>();
    }
}