using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Student> Students { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Coach>().ToTable("Coaches");
        builder.Entity<Coach>().HasKey(p => p.Id);
        builder.Entity<Coach>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Coach>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        // Relationships
        builder.Entity<Coach>()
            .HasMany(p => p.Students)
            .WithOne(p => p.Coach)
            .HasForeignKey(p => p.CoachId);
        
        builder.Entity<Student>().ToTable("Students");
        builder.Entity<Student>().HasKey(p => p.Id);
        builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Student>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Student>().Property(p => p.Description).HasMaxLength(120);
        
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}