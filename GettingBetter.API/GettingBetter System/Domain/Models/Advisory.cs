namespace LearningCenter.API.Learning.Domain.Models;

public class Advisory
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CoachId { get; set; }
    public string Date { get; set; }
    
}