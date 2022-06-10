using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Resources;

public class StudentResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CoachResource Coach { get; set; }
}