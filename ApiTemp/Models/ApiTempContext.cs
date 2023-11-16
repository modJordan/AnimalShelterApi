using Microsoft.EntityFrameworkCore;

namespace  ApiTemp.Models
{
  public class ApiTempContext : DbContext
  {
    public DbSet<Model> Models {get; set;}

    public ApiTempContext(DbContextOptions<ApiTempContext> options) : base(options)
    {
    }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Model>()
        .HasData(
          new Model { ModelId = 1, Name = "Linux For Dummies", Description = "lorem ipsum"}
        );
      }
    }
  }