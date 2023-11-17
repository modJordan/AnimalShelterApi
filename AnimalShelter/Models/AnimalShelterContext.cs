using Microsoft.EntityFrameworkCore;

namespace  AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public DbSet<Animal> Animals {get; set;}

    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {
    }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Fido", Description = "Loves ketchup and playing fetch"}
        );
      }
    }
  }