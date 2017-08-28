using Microsoft.EntityFrameworkCore;

namespace RagnarEstimator.Models
{
  public class RagnarEstimatorContext : DbContext{
    public RagnarEstimatorContext(DbContextOptions<RagnarEstimatorContext> options) : base(options) {}
    public DbSet<Runner> Runners {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<Lap> Laps {get; set;}
    public DbSet<Race> Races {get; set;}
  }
} 