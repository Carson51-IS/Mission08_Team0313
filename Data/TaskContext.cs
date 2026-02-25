using Microsoft.EntityFrameworkCore;
using Mission08_Team0313.Models;

namespace Mission08_Team0313.Data;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    public DbSet<TaskEntry> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntry>().HasKey(t => t.TaskId);
        modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

        // Seed categories for the dropdown: Home, School, Work, Church
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }
}
