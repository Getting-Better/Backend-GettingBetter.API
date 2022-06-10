namespace LearningCenter.API.Learning.Domain.Models;

public class Coach
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships

    public IList<Student> Students { get; set; } = new List<Student>();
}




