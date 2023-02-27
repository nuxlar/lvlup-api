using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LvlUpApi.Models;

namespace LvlUpApi.Controllers
{
  [Route("api/HasDones")]
  [ApiController]
  public class HasDonesController : ControllerBase
  {
    private readonly HasDoneContext _context;

    public HasDonesController(HasDoneContext context)
    {
      _context = context;
    }

    // GET: api/HasDones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HasDone>>> GetHasDones()
    {
      if (_context.HasDones == null)
      {
        return NotFound();
      }
      return await _context.HasDones.ToListAsync();
    }

    // GET: api/HasDones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HasDone>> GetHasDone(long id)
    {
      if (_context.HasDones == null)
      {
        return NotFound();
      }
      var hasDone = await _context.HasDones.FindAsync(id);

      if (hasDone == null)
      {
        return NotFound();
      }

      return hasDone;
    }

    // PUT: api/HasDones/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHasDone(long id, HasDone hasDone)
    {
      if (id != hasDone.Id)
      {
        return BadRequest();
      }

      _context.Entry(hasDone).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!HasDoneExists(id))
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

    // POST: api/HasDones
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<HasDone>> PostHasDone(HasDone hasDone)
    {
      if (_context.HasDones == null)
      {
        return Problem("Entity set 'HasDoneContext.HasDones'  is null.");
      }
      _context.HasDones.Add(hasDone);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetHasDone), new { id = hasDone.Id }, hasDone);
    }

    // DELETE: api/HasDones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHasDone(long id)
    {
      if (_context.HasDones == null)
      {
        return NotFound();
      }
      var hasDone = await _context.HasDones.FindAsync(id);
      if (hasDone == null)
      {
        return NotFound();
      }

      _context.HasDones.Remove(hasDone);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool HasDoneExists(long id)
    {
      return (_context.HasDones?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
