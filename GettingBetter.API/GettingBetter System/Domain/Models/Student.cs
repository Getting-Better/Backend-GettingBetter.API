namespace LearningCenter.API.Learning.Domain.Models;

public class Student
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    // Relationships
    
    public int CoachId { get; set; }
    public Coach Coach { get; set; }
}