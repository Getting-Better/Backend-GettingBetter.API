namespace LearningCenter.API.Learning.Domain.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Title{ get; set; }
    public string Description { get; set; }
    public int StudentId { get; set; }
    public int CyberId { get; set; }
    public string Date { get; set; } 
}