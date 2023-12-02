using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using AnimalShelter.Contracts;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    private readonly IAnimalRepository _repository;
    public AnimalsController(AnimalShelterContext db, IAnimalRepository repository)
    {
      _db = db;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string name, string description, string species, int age)
    {
        IQueryable<Animal> query = _db.Animals.AsQueryable();

        if (name != null)
        {
            query = query.Where(entry => entry.Name == name);
        }

        if (description != null)
        {
            query = query.Where(entry => entry.Description == description);
        }
        if (species != null)
        {
            query = query.Where(entry => entry.Species == species);
        }
        if (age != 0)
        {
            query = query.Where(entry => entry.Age == age);
        }

        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
        Animal animal = await _db.Animals.FindAsync(id);

        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    [HttpGet]
        [Route("paging-filter")]
        public IActionResult GetAnimalPagingData([FromQuery] PagedParameters animalParameters)
        {
            var animal = _repository.GetAnimals(animalParameters);

            var metadata = new
            {
                animal.TotalCount,
                animal.PageSize,
                animal.CurrentPage,
                animal.TotalPages,
                animal.HasNext,
                animal.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(animal);
        }

    [HttpGet]
    [Route("getpaging-by-param")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetparksByFilter(
            PagedParameters ownerParameters
        )
        {
            if (_db.Animals == null)
            {
                return NotFound();
            }
            return await _db.Animals
                .OrderBy(on => on.AnimalId)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToListAsync();
        }



    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
        _db.Animals.Add(animal);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }
   


    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnimal(int id, Animal animal)
    {
        if (id != animal.AnimalId)
        {
            return BadRequest();
        }

        _db.Animals.Update(animal);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!AnimalExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }

        return NoContent();
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        var animal = await _db.Animals.FindAsync(id);
        if (animal == null)
        {
            return NotFound();
        }

        _db.Animals.Remove(animal);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    private bool AnimalExists(int id)
    {
        return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}