using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTemp.Models;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ApiTemp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModelsController : ControllerBase
  {
    private readonly ApiTempContext _db;
    public ModelsController(ApiTempContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Model>>> Get(string name, string description)
    {
        IQueryable<Model> query = _db.Models.AsQueryable();

        if (name != null)
        {
            query = query.Where(entry => entry.Name == name);
        }

        if (description != null)
        {
            query = query.Where(entry => entry.Description == description);
        }

        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Model>> GetModel(int id)
    {
        Model model = await _db.Models.FindAsync(id);

        if (model == null)
        {
            return NotFound();
        }

        return model;
    }

    [HttpPost]
    public async Task<ActionResult<Model>> Post(Model model)
    {
        _db.Models.Add(model);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetModel), new{ id = model.ModelId }, model);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutModel(int id, Model model)
    {
        if (id != model.ModelId)
        {
            return BadRequest();
        }

        _db.Models.Update(model);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ModelExists(id))
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

    // DELETE: api/Models/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModel(int id)
    {
        var model = await _db.Models.FindAsync(id);
        if (model == null)
        {
            return NotFound();
        }

        _db.Models.Remove(model);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    private bool ModelExists(int id)
    {
        return _db.Models.Any(e => e.ModelId == id);
    }
  }
}