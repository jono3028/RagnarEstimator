using Microsoft.EntityFrameworkCore;

namespace RagnarEstimator.Models
{
  public class RagnarEstimatorContext : DbContext{
    public RagnarEstimatorContext(DbContextOptions<RagnarEstimatorContext> options) : base(options) {}
    public DbSet<User> Users {get; set;}
    public DbSet<RaceSegment> Segments {get; set;}
    public DbSet<Race> Races {get; set;}
  }
}